using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class IntegerMetaFieldEditionPanelViewModel : MetaFieldEditionPanelViewModel<IIntegerMetaField>
    {
        #region Properties

        public virtual TextBoxFieldItemViewModel DefaultValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MaxValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MinValueFieldItemViewModel { get; protected set; }

        #endregion

        #region Methods

        public static IntegerMetaFieldEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new IntegerMetaFieldEditionPanelViewModel());
        }

        public override void Initialize(IIntegerMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaIntegerMetaField = EntityService.GetMetaEntity(nameof(IIntegerMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaIntegerMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeIntegerMetaField(metaIntegerMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IIntegerMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<int?>(nameof(IIntegerMetaField.MinValue));
            MinValueFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.MinValue.ToString());
            EditableItemsFields.Add(MinValueFieldItemViewModel);
            fieldValidator = GetFieldValidator<int?>(nameof(IIntegerMetaField.MaxValue));
            MaxValueFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.MaxValue.ToString());
            fieldValidator = GetFieldValidator<int?>(nameof(IIntegerMetaField.DefaultValue));
            EditableItemsFields.Add(MaxValueFieldItemViewModel);
            DefaultValueFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.DefaultValue.ToString());
            EditableItemsFields.Add(DefaultValueFieldItemViewModel);
        }

        #endregion
    }
}