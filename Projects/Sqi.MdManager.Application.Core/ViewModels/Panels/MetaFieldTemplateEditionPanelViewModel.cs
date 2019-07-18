using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework;
using Sqi.Framework.Application.ViewModels.Panels;
using Sqi.Framework.Models;
using Sqi.Framework.Services;
using Sqi.MdManager.Application.Core.Resources;
using Sqi.MdManager.Services;
using System;
using System.Collections.Generic;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    [POCOViewModel]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class MetaFieldTemplateEditionPanelViewModel : EntityEditionPanelViewModel
    {
        #region Properties
        private IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();
        private IMetaDataService MetaDataService { get; } = InstanceLocator.Current.GetInstance<IMetaDataService>();
        private MainViewModel MainViewModel => this.GetParentViewModel<MainViewModel>();
        private IMetaEntity MetaEntity => Entity as IMetaEntity;
        private Action<IEnumerable<IEntity>> DeleteAction { get; }
        private Func<IEnumerable<IEntity>> GetEntitiesFunction { get; }
        private Action OpenCreationAction { get; }
        private Action<IEntity> OpenModificationAction { get; }
        private IMetaEntity MetaFieldTemplate { get; set; }
        #endregion

        #region Constructors

        protected MetaFieldTemplateEditionPanelViewModel()
        {
            ValidateAction = Validate;
            GetEntitiesFunction = RefreshMetaFields;
            OpenCreationAction = null;
            OpenModificationAction = OpenMetaFieldTemplateEdition;
            DeleteAction = DeleteMetaFieldTemplate;
        }

        #endregion

        #region Methods

        public static MetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new MetaFieldTemplateEditionPanelViewModel());
        }

        public void Initialize(IMetaEntity metaEntity)
        {
            MetaFieldTemplate = EntityService.GetMetaEntity(nameof(IMetaFieldTemplate));
            EntityValidator = EntityService.GetEntityValidator(MetaFieldTemplate);
            var metaMetaField = EntityService.GetMetaEntity(nameof(IMetaField));
            if (metaEntity == null)
            {
                metaEntity = MetaDataService.InitializeMetaEntity(MetaFieldTemplate);
            }
            else
            {
                metaEntity = EntityService.GetMetaEntity(metaEntity.Id);
            }
            Caption = MdManagerLabels.MetaFieldTemplateLabel;

            Entity = metaEntity;
        }

        private bool CanCreateMetaField() => !EntityService.IsEntityNew(MetaEntity);

        private void Delete(IEntity entity)
        {

        }

        private void DeleteMetaFieldTemplate(IEnumerable<IEntity> metaFields)
        {
        }

        private IFieldValidator<T> GetFieldValidator<T>(string fieldName) =>
            EntityService.GetFieldValidator<T>(EntityValidator, fieldName);

        private void InitializeFieldValidators(IMetaEntity metaEntity)
        {
            IFieldValidator fieldValidator = GetFieldValidator<string>(nameof(IMetaEntity.InterfaceName));
        }

        private void OpenMetaFieldTemplateEdition(IEntity metaField)
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
