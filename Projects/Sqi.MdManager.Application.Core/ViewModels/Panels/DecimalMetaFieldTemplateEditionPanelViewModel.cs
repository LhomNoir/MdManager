using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;
using System.Globalization;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class DecimalMetaFieldTemplateEditionPanelViewModel : MetaFieldEditionPanelViewModel<IDecimalMetaField>
    {
        #region Properties

        public virtual TextBoxFieldItemViewModel DefaultValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MaxValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MinValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel ScaleFieldItemViewModel { get; protected set; }

        #endregion

        #region Methods

        public static DecimalMetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new DecimalMetaFieldTemplateEditionPanelViewModel());
        }

        public override void Initialize(IDecimalMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaDecimalMetaField = EntityService.GetMetaEntity(nameof(IDecimalMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaDecimalMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeDecimalMetaField(metaDecimalMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IDecimalMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<decimal?>(nameof(IDecimalMetaField.MinValue));
            MinValueFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity,
                metaField.MinValue?.ToString(CultureInfo.CurrentCulture));
            EditableItemsFields.Add(MinValueFieldItemViewModel);

            fieldValidator = GetFieldValidator<decimal?>(nameof(IDecimalMetaField.MaxValue));
            MaxValueFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity,
                metaField.MaxValue?.ToString(CultureInfo.CurrentCulture));
            EditableItemsFields.Add(MaxValueFieldItemViewModel);

            fieldValidator = GetFieldValidator<int?>(nameof(IDecimalMetaField.Scale));
            ScaleFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.Scale.ToString());
            EditableItemsFields.Add(ScaleFieldItemViewModel);

            fieldValidator = GetFieldValidator<decimal?>(nameof(IDecimalMetaField.DefaultValue));
            DefaultValueFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity,
                metaField.DefaultValue?.ToString(CultureInfo.CurrentCulture));
            EditableItemsFields.Add(DefaultValueFieldItemViewModel);
        }

        #endregion
    }
}