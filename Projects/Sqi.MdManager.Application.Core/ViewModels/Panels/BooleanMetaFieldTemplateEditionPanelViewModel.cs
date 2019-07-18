using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class BooleanMetaFieldTemplateEditionPanelViewModel : MetaFieldEditionPanelViewModel<IBooleanMetaField>
    {
        #region Properties

        public virtual CheckBoxFieldItemViewModel DefaultValueFieldItemViewModel { get; protected set; }

        #endregion

        #region Methods

        public static BooleanMetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new BooleanMetaFieldTemplateEditionPanelViewModel());
        }

        public override void Initialize(IBooleanMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaBooleanMetaField = EntityService.GetMetaEntity(nameof(IBooleanMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaBooleanMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeBooleanMetaField(metaBooleanMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IBooleanMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<bool?>(nameof(IBooleanMetaField.DefaultValue));
            DefaultValueFieldItemViewModel =
                CheckBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.DefaultValue);
            EditableItemsFields.Add(DefaultValueFieldItemViewModel);
        }

        #endregion
    }
}