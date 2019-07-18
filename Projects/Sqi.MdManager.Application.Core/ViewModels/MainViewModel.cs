using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework;
using Sqi.Framework.Application.Resources;
using Sqi.Framework.Application.ViewModels;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Application.ViewModels.Panels;
using Sqi.Framework.Models;
using Sqi.Framework.Services;
using Sqi.MdManager.Application.Core.Resources;
using Sqi.MdManager.Application.Core.ViewModels.Items;
using Sqi.MdManager.Application.Core.ViewModels.Panels;
using Sqi.MdManager.Services;
using System;
using System.Collections.Generic;

namespace Sqi.MdManager.Application.Core.ViewModels
{
    [POCOViewModel]
    public class MainViewModel : MainViewModelBase
    {
        #region Properties

        public virtual int ActiveDocumentIndex { get; set; }
        public virtual string AddMetaEntityLabel { get; }
        public virtual string AddRegularExpressionLabel { get; }
        public virtual string ApplicationTitle { get; } = MdManagerLabels.ApplicationTitle;
        public virtual string ListOfMetaEntityLabel { get; }
        public virtual string ListOfRegularExpressionLabel { get; }
        public virtual string ListOfTemplateLabel { get; }
        public virtual string MetadataLabel { get; } = MdManagerLabels.MenuMetadataLabel;
        private IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();

        private IMetaDataService MetaDataService { get; } = InstanceLocator.Current.GetInstance<IMetaDataService>();
        private IMetaEntity MetaMetaEntity { get; }
        private IMetaEntity MetaRegularExpression { get; }
        public IMetaEntity MetaEntityTemplate { get; set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            MetaMetaEntity = EntityService.GetMetaEntity(nameof(IMetaEntity));
            var entityValidator = EntityService.GetEntityValidator(MetaMetaEntity);
            ListOfMetaEntityLabel =
                string.Format(ApplicationLabels.MenuListOfLabel, entityValidator.MetaEntity.PlurialLabel);
            AddMetaEntityLabel = string.Format(ApplicationLabels.MenuAddFLabel, entityValidator.MetaEntity.Label);

            MetaRegularExpression = EntityService.GetMetaEntity(nameof(IRegularExpression));
            var regularExpressionValidator = EntityService.GetEntityValidator(MetaRegularExpression);
            ListOfRegularExpressionLabel = string.Format(ApplicationLabels.MenuListOfLabel,
                regularExpressionValidator.MetaEntity.PlurialLabel);
            AddRegularExpressionLabel = string.Format(ApplicationLabels.MenuAddFLabel,
                regularExpressionValidator.MetaEntity.Label);

            MetaEntityTemplate = EntityService.GetMetaEntity(nameof(IMetaField));
            ListOfTemplateLabel = string.Format(ApplicationLabels.MenuListOfTemplateLabel, MdManagerLabels.MetaFieldTemplateLabels);

            OpenMetaEntityList();
        }

        #endregion

        #region Methods

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void OpenMetaEntityList()
        {
            var entityValidator = EntityService.GetEntityValidator(MetaMetaEntity);
            Panels.Add(EntityListPanelViewModel.Create(MetaDataService.GetMetaEntities, OpenMetaEntityCreation,
                OpenMetaEntityEdition, DeleteMetaEntities, entityValidator));
            SetFocusOnSelectedPanel();
        }

        public void OpenMetaFieldEdition(IEntity metaField)
        {
            MetaFieldEditionPanelViewModel panelViewModel = null;
            switch (metaField)
            {
                case IBooleanMetaField booleanMetaField:
                    panelViewModel = BooleanMetaFieldEditionPanelViewModel.Create();
                    ((BooleanMetaFieldEditionPanelViewModel)panelViewModel).Initialize(booleanMetaField);
                    break;
                case IIntegerMetaField integerMetaField:
                    panelViewModel = IntegerMetaFieldEditionPanelViewModel.Create();
                    ((IntegerMetaFieldEditionPanelViewModel)panelViewModel).Initialize(integerMetaField);
                    break;
                case IDecimalMetaField decimalMetaField:
                    panelViewModel = DecimalMetaFieldEditionPanelViewModel.Create();
                    ((DecimalMetaFieldEditionPanelViewModel)panelViewModel).Initialize(decimalMetaField);
                    break;
                case IDateTimeMetaField dateTimeMetaField:
                    panelViewModel = DateTimeMetaFieldEditionPanelViewModel.Create();
                    ((DateTimeMetaFieldEditionPanelViewModel)panelViewModel).Initialize(dateTimeMetaField);
                    break;
                case IStringMetaField stringMetaField:
                    panelViewModel = StringMetaFieldEditionPanelViewModel.Create();
                    ((StringMetaFieldEditionPanelViewModel)panelViewModel).Initialize(stringMetaField);
                    break;
                case IEntityMetaField entityMetaField:
                    panelViewModel = EntityMetaFieldEditionPanelViewModel.Create();
                    ((EntityMetaFieldEditionPanelViewModel)panelViewModel).Initialize(entityMetaField);
                    break;
            }

            if (panelViewModel != null)
            {
                Panels.Add(panelViewModel);
                SetFocusOnSelectedPanel();
            }
        }

        public void SetFocusOnSelectedPanel() => ActiveDocumentIndex = Panels.Count - 1;

        public void ShowAbout()
        {
        }

        private void DeleteMetaEntities(IEnumerable<IEntity> metaEntities)
        {
        }

        private void OpenMetaEntityCreation()
        {
            OpenMetaEntityEdition();
        }
        public void OpenMetaEntityEdition()
        {
            OpenMetaEntityEdition(null);
        }

        private void OpenMetaEntityEdition(IEntity metaEntity)
        {
            var panelViewModel = MetaEntityEditionPanelViewModel.Create();
            panelViewModel.SetParentViewModel(this);
            panelViewModel.Initialize(metaEntity as IMetaEntity);
            Panels.Add(panelViewModel);
            SetFocusOnSelectedPanel();
        }

        public void OpenRegularExpressionList()
        {
            var entityValidator = EntityService.GetEntityValidator(MetaRegularExpression);
            Panels.Add(EntityListPanelViewModel.Create(MetaDataService.GetRegularExpressions,
                OpenRegularExpressionCreation, OpenRegularExpressionEdition, DeleteRegularExpression, entityValidator));
            SetFocusOnSelectedPanel();
        }

        private void OpenRegularExpressionCreation()
        {
            OpenRegularExpressionEdition();
        }

        public void OpenRegularExpressionEdition()
        {
            OpenRegularExpressionEdition(null);
        }

        private void OpenRegularExpressionEdition(IEntity entity)
        {
            var regularExpression = entity as IRegularExpression;
            var entityValidator = EntityService.GetEntityValidator(MetaRegularExpression);

            if (regularExpression == null)
            {
                regularExpression = MetaDataService.InitializeRegularExpression(MetaRegularExpression);
            }

            var entityItemViewModels = new Dictionary<IEntityMetaField, List<IEntityItemViewModel>>();
            var metaField = (IEntityMetaField)
                EntityService.GetMetaField<IEntity>(MetaRegularExpression, nameof(IRegularExpression.CreationUser));
            var mdUserItemViewModels =
                new List<IEntityItemViewModel> { MdUserItemViewModel.Create(regularExpression.CreationUser) };
            entityItemViewModels.Add(metaField, mdUserItemViewModels);
            metaField = (IEntityMetaField)
                EntityService.GetMetaField<IEntity>(MetaRegularExpression, nameof(IRegularExpression.LastUpdateUser));
            mdUserItemViewModels =
                new List<IEntityItemViewModel> { MdUserItemViewModel.Create(regularExpression.LastUpdateUser) };
            entityItemViewModels.Add(metaField, mdUserItemViewModels);

            Panels.Add(EntityEditionPanelViewModel.Create(ValidateRegularExpression, DeleteRegularExpressions,
                entityValidator, regularExpression, entityItemViewModels));

            SetFocusOnSelectedPanel();
        }

        private void ValidateRegularExpression(IEntityValidator entityValidator, IEntity regularExpression)
        {
            MetaDataService.SaveRegularExpression(entityValidator, (IRegularExpression)regularExpression);
        }

        private void DeleteRegularExpression(IEnumerable<IEntity> regularExpressions)
        {
        }

        private void DeleteRegularExpressions(IEntity regularExpression)
        {
        }

        public void OpenMetaFieldTemplateList()
        {
            Panels.Add(MetaFieldTemplateListPanelViewModel.Create());
            SetFocusOnSelectedPanel();
        }

        private void OpenMetaFieldTemplateCreation()
        {
        }

        public void OpenMetaFieldTemplateEdition(IEntity metaField)
        {
            MetaFieldEditionPanelViewModel panelViewModel = null;
            switch (metaField)
            {
                case IBooleanMetaField booleanMetaField:
                    panelViewModel = BooleanMetaFieldTemplateEditionPanelViewModel.Create();
                    ((BooleanMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(booleanMetaField);
                    break;
                case IIntegerMetaField integerMetaField:
                    panelViewModel = IntegerMetaFieldTemplateEditionPanelViewModel.Create();
                    ((IntegerMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(integerMetaField);
                    break;
                case IDecimalMetaField decimalMetaField:
                    panelViewModel = DecimalMetaFieldTemplateEditionPanelViewModel.Create();
                    ((DecimalMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(decimalMetaField);
                    break;
                case IDateTimeMetaField dateTimeMetaField:
                    panelViewModel = DateTimeMetaFieldTemplateEditionPanelViewModel.Create();
                    ((DateTimeMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(dateTimeMetaField);
                    break;
                case IStringMetaField stringMetaField:
                    panelViewModel = StringMetaFieldTemplateEditionPanelViewModel.Create();
                    ((StringMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(stringMetaField);
                    break;
                case IEntityMetaField entityMetaField:
                    panelViewModel = EntityMetaFieldTemplateEditionPanelViewModel.Create();
                    ((EntityMetaFieldTemplateEditionPanelViewModel)panelViewModel).Initialize(entityMetaField);
                    break;
            }

            if (panelViewModel != null)
            {
                Panels.Add(panelViewModel);
                SetFocusOnSelectedPanel();
            }
        }

        public void DeleteMetaFiledTemplate(IEnumerable<IEntity> regularExpressions)
        {
        }

        #endregion
    }
}