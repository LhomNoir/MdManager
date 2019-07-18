using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Application.ViewModels.Panels;
using Sqi.Framework.Models;
using Sqi.Framework.Services;
using Sqi.MdManager.Application.Core.Resources;
using Sqi.MdManager.Application.Core.ViewModels.Items;
using Sqi.MdManager.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    [POCOViewModel]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class MetaEntityEditionPanelViewModel : EntityMetaFieldEditionPanelViewModel
    {
        #region Properties

        public virtual string CreateBooleanMetaFieldLabel { get; protected set; }
        public virtual string CreateDateTimeMetaFieldLabel { get; protected set; }
        public virtual string CreateDecimalMetaFieldLabel { get; protected set; }
        public virtual string CreateEntityMetaFieldLabel { get; protected set; }
        public virtual string CreateIntegerMetaFieldLabel { get; protected set; }
        public virtual string CreateStringMetaFieldLabel { get; protected set; }
        public virtual TextBoxFieldItemViewModel DescriptionFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel InterfaceNameFieldItemViewModel { get; protected set; }
        public virtual CheckBoxFieldItemViewModel IsMasculineFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel LabelFieldItemViewModel { get; protected set; }
        public virtual EntityListPanelViewModel MetaFieldListPanelViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel PlurialLabelFieldItemViewModel { get; protected set; }
        private IModelFactory ModelFactory { get; } = InstanceLocator.Current.GetInstance<IModelFactory>();
        private IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();
        private IMetaDataService MetaDataService { get; } = InstanceLocator.Current.GetInstance<IMetaDataService>();
        private MainViewModel MainViewModel => this.GetParentViewModel<MainViewModel>();
        private IMetaEntity MetaBooleanMetaField { get; set; }
        private IMetaEntity MetaDateTimeMetaField { get; set; }
        private IMetaEntity MetaDecimalMetaField { get; set; }
        private IMetaEntity MetaEntity => Entity as IMetaEntity;
        private IMetaEntity MetaEntityMetaField { get; set; }
        private IMetaEntity MetaIntegerMetaField { get; set; }
        private IMetaEntity MetaStringMetaField { get; set; }

        #endregion

        #region Constructors

        protected MetaEntityEditionPanelViewModel()
        {
            ValidateAction = Validate;
            DeleteAction = Delete;
        }

        #endregion

        #region Methods

        public static MetaEntityEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new MetaEntityEditionPanelViewModel());
        }

        public bool CanCreateBooleanMetaField() => CanCreateMetaField();

        public bool CanCreateDateTimeMetaField() => CanCreateMetaField();

        public bool CanCreateDecimalMetaField() => CanCreateMetaField();

        public bool CanCreateEntityMetaField() => CanCreateMetaField();

        public bool CanCreateIntegerMetaField() => CanCreateMetaField();

        public bool CanCreateStringMetaField() => CanCreateMetaField();

        public void OpenMetaFieldTemplatePanel()
        {
            var metaFieldTemplate = MetaFieldTemplateItemViewModel?.SelectedValue.Value;
            MainViewModel.OpenMetaFieldTemplateEdition(metaFieldTemplate);
        }

        public void CreateBooleanMetaField()
        {
            var metaField = MetaDataService.InitializeBooleanMetaField(MetaBooleanMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void CreateDateTimeMetaField()
        {
            var metaField = MetaDataService.InitializeDateTimeMetaField(MetaDateTimeMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void CreateDecimalMetaField()
        {
            var metaField = MetaDataService.InitializeDecimalMetaField(MetaDecimalMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void CreateEntityMetaField()
        {
            var metaField = MetaDataService.InitializeEntityMetaField(MetaEntityMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void CreateIntegerMetaField()
        {
            var metaField = MetaDataService.InitializeIntegerMetaField(MetaIntegerMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void CreateStringMetaField()
        {
            var metaField = MetaDataService.InitializeStringMetaField(MetaStringMetaField, MetaEntity);
            OpenMetaFieldEdition(metaField);
        }

        public void Initialize(IMetaEntity metaEntity)
        {
            var metaMetaEntity = EntityService.GetMetaEntity(nameof(IMetaEntity));
            EntityValidator = EntityService.GetEntityValidator(metaMetaEntity);
            var metaMetaField = EntityService.GetMetaEntity(nameof(IMetaField));
            var metaFieldValidator = EntityService.GetEntityValidator(metaMetaField);
            if (metaEntity == null)
            {
                metaEntity = MetaDataService.InitializeMetaEntity(metaMetaEntity);
            }
            else
            {
                metaEntity = EntityService.GetMetaEntity(metaEntity.Id);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaEntity;
            MetaFieldListPanelViewModel = EntityListPanelViewModel.Create(RefreshMetaFields, null, OpenMetaFieldEdition,
                DeleteMetaField, metaFieldValidator);

            MetaBooleanMetaField = EntityService.GetMetaEntity(nameof(IBooleanMetaField));
            CreateBooleanMetaFieldLabel = string.Format(MdManagerLabels.CreateEntityLabel, MetaBooleanMetaField.Label);
            MetaIntegerMetaField = EntityService.GetMetaEntity(nameof(IIntegerMetaField));
            CreateIntegerMetaFieldLabel = string.Format(MdManagerLabels.CreateEntityLabel, MetaIntegerMetaField.Label);
            MetaDecimalMetaField = EntityService.GetMetaEntity(nameof(IDecimalMetaField));
            CreateDecimalMetaFieldLabel = string.Format(MdManagerLabels.CreateEntityLabel, MetaDecimalMetaField.Label);
            MetaDateTimeMetaField = EntityService.GetMetaEntity(nameof(IDateTimeMetaField));
            CreateDateTimeMetaFieldLabel =
                string.Format(MdManagerLabels.CreateEntityLabel, MetaDateTimeMetaField.Label);
            MetaStringMetaField = EntityService.GetMetaEntity(nameof(IStringMetaField));
            CreateStringMetaFieldLabel = string.Format(MdManagerLabels.CreateEntityLabel, MetaStringMetaField.Label);
            MetaEntityMetaField = EntityService.GetMetaEntity(nameof(IEntityMetaField));
            CreateEntityMetaFieldLabel = string.Format(MdManagerLabels.CreateEntityLabel, MetaEntityMetaField.Label);

            InitializeFieldValidators(metaEntity);
        }

        private bool CanCreateMetaField() => !EntityService.IsEntityNew(MetaEntity);

        private void Delete(IEntity entity)
        {
        }

        private void DeleteMetaField(IEnumerable<IEntity> metaFields)
        {
        }

        private IFieldValidator<T> GetFieldValidator<T>(string fieldName) =>
            EntityService.GetFieldValidator<T>(EntityValidator, fieldName);

        private void InitializeFieldValidators(IMetaEntity metaEntity)
        {
            IFieldValidator fieldValidator = GetFieldValidator<string>(nameof(IMetaEntity.InterfaceName));
            InterfaceNameFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaEntity.InterfaceName);
            EditableItemsFields.Add(InterfaceNameFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaEntity.Label));
            LabelFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaEntity.Label);
            EditableItemsFields.Add(LabelFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaEntity.PlurialLabel));
            PlurialLabelFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaEntity.PlurialLabel);
            EditableItemsFields.Add(PlurialLabelFieldItemViewModel);
            fieldValidator = GetFieldValidator<bool?>(nameof(IMetaEntity.IsMasculine));
            IsMasculineFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaEntity.IsMasculine);
            EditableItemsFields.Add(IsMasculineFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaEntity.Description));
            DescriptionFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaEntity.Description);
            EditableItemsFields.Add(DescriptionFieldItemViewModel);

            var metaField = ModelFactory.CreateMetaField(
                "MetaFieldTemplate",
                "Ajouter un méta-champ",
                "Choisissez un model de méta champ");

            var metaFieldTemplates = MetaDataService.GetMetaFieldTemplates().OrderBy(me => me.Label).ToList();
            var metaFieldTemplateViewModels = metaFieldTemplates.Select(MetaFieldItemTemplateViewModel.Create);
            fieldValidator = ModelFactory.CreateFieldValidator<IEntity>(metaField);
            EntityService.CreateFieldValidator(fieldValidator);
            MetaFieldTemplateItemViewModel =
                EntityFieldItemViewModel.Create(fieldValidator, Entity, metaFieldTemplateViewModels, metaField);
            EditableItemsFields.Add(MetaFieldTemplateItemViewModel);
        }

        private void OpenMetaFieldEdition(IEntity metaField)
        {
            MainViewModel.OpenMetaFieldEdition(metaField);
        }

        private IEnumerable<IMetaField> RefreshMetaFields()
        {
            if (EntityService.IsEntityNew(MetaEntity))
            {
                return new List<IMetaField>();
            }

            return EntityService.GetMetaEntity(MetaEntity.Id).MetaFields;
        }

        private void Validate(IEntityValidator entityValidator, IEntity entity)
        {
            MetaDataService.SaveMetaEntity(entityValidator, (IMetaEntity)entity);
        }
        #endregion
    }
}