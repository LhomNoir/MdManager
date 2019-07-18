using DevExpress.Mvvm.DataAnnotations;
using Sqi.Framework;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Application.ViewModels.Panels;
using Sqi.Framework.Models;
using Sqi.Framework.Services;
using Sqi.MdManager.Application.Core.ViewModels.Items;
using Sqi.MdManager.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    [POCOViewModel]
    public abstract class MetaFieldEditionPanelViewModel : EntityEditionPanelViewModel
    {
        #region Properties
        public virtual string MetaFieldTemplateCreateLabel { get; set; }
        public virtual string CreateMetaFieldLabel { get; set; }

        public virtual TextBoxFieldItemViewModel DescriptionFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel FieldNameFieldItemViewModel { get; protected set; }
        public virtual CheckBoxFieldItemViewModel IsReadOnlyFieldItemViewModel { get; protected set; }
        public virtual CheckBoxFieldItemViewModel IsRequiredFieldItemViewModel { get; protected set; }
        public virtual CheckBoxFieldItemViewModel IsResetOnCopyFieldItemViewModel { get; protected set; }
        public virtual CheckBoxFieldItemViewModel IsVisibleFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel LabelFieldItemViewModel { get; protected set; }
        public virtual EntityFieldItemViewModel MetaEntityFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel StringFormatFieldItemViewModel { get; protected set; }
        protected IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();
        protected IMetaDataService MetaDataService { get; } = InstanceLocator.Current.GetInstance<IMetaDataService>();
        protected IModelFactory ModelFactory { get; } = InstanceLocator.Current.GetInstance<IModelFactory>();
        public virtual EntityFieldItemViewModel MetaFieldTemplateItemViewModel { get; protected set; }

        public virtual EntityFieldItemViewModel ValueTypeFieldItemViewModel { get; protected set; }

        #endregion

        #region Constructors

        protected MetaFieldEditionPanelViewModel()
        {
            ValidateAction = Validate;
            DeleteAction = Delete;
        }

        #endregion

        #region Methods

        protected IFieldValidator<T> GetFieldValidator<T>(string fieldName) =>
            EntityService.GetFieldValidator<T>(EntityValidator, fieldName);

        private void Delete(IEntity entity)
        {
        }

        private void Validate(IEntityValidator entityValidator, IEntity entity)
        {
            MetaDataService.SaveMetaField(entityValidator, (IMetaField)entity);
        }

        #endregion
    }

    [POCOViewModel]
    public abstract class MetaFieldEditionPanelViewModel<TMetaField> : MetaFieldEditionPanelViewModel
        where TMetaField : IMetaField
    {
        #region Methods

        public abstract void Initialize(TMetaField metaField, IMetaEntity metaEntity = null);

        protected virtual void InitializeFieldValidators(TMetaField metaField)
        {
            IFieldValidator fieldValidator = GetFieldValidator<string>(nameof(IMetaField.FieldName));
            FieldNameFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.FieldName);
            EditableItemsFields.Add(FieldNameFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaField.Label));
            LabelFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.Label);
            EditableItemsFields.Add(LabelFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaField.Description));
            DescriptionFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.Description);
            EditableItemsFields.Add(DescriptionFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IMetaField.StringFormat));
            StringFormatFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.StringFormat);
            EditableItemsFields.Add(StringFormatFieldItemViewModel);
            fieldValidator = GetFieldValidator<bool?>(nameof(IMetaField.IsRequired));
            IsRequiredFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.IsRequired);
            EditableItemsFields.Add(IsRequiredFieldItemViewModel);
            fieldValidator = GetFieldValidator<bool?>(nameof(IMetaField.IsReadOnly));
            IsReadOnlyFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.IsReadOnly);
            EditableItemsFields.Add(IsReadOnlyFieldItemViewModel);
            fieldValidator = GetFieldValidator<bool?>(nameof(IMetaField.IsVisible));
            IsVisibleFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.IsVisible);
            EditableItemsFields.Add(IsVisibleFieldItemViewModel);
            fieldValidator = GetFieldValidator<bool?>(nameof(IMetaField.IsResetOnCopy));
            IsResetOnCopyFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.IsResetOnCopy);
            EditableItemsFields.Add(IsResetOnCopyFieldItemViewModel);
            fieldValidator = GetFieldValidator<IEntity>(nameof(IMetaField.MetaEntity));
            var metaEntities = new List<MetaEntityItemViewModel> { MetaEntityItemViewModel.Create(metaField.MetaEntity) };
            MetaEntityFieldItemViewModel =
                EntityFieldItemViewModel.Create(fieldValidator, Entity, metaEntities, metaField.MetaEntity);
            EditableItemsFields.Add(MetaEntityFieldItemViewModel);

            var newMetaField = ModelFactory.CreateMetaField(
                "MetaFieldTemplate",
                "Ajouter un méta-champ",
                "Choisissez un model de méta champ");

            MetaFieldTemplateCreateLabel = newMetaField.Label;

            var metaFieldTemplates = MetaDataService.GetMetaFieldTemplates().OrderBy(me => me.Label).ToList();
            var metaFieldTemplateViewModels = metaFieldTemplates.Select(MetaFieldItemTemplateViewModel.Create);
            fieldValidator = ModelFactory.CreateFieldValidator<IEntity>(newMetaField);
            EntityService.CreateFieldValidator(fieldValidator);
            MetaFieldTemplateItemViewModel =
                EntityFieldItemViewModel.Create(fieldValidator, Entity, metaFieldTemplateViewModels, newMetaField);
            EditableItemsFields.Add(MetaFieldTemplateItemViewModel);
        }

        #endregion
    }
}