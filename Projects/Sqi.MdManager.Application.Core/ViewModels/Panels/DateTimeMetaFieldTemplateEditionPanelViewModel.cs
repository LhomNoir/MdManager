using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;
using System;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class DateTimeMetaFieldTemplateEditionPanelViewModel : MetaFieldEditionPanelViewModel<IDateTimeMetaField>
    {
        #region Properties

        public virtual DateFieldItemViewModel DefaultValueFieldItemViewModel { get; protected set; }
        public virtual DateFieldItemViewModel MaxValueFieldItemViewModel { get; protected set; }
        public virtual DateFieldItemViewModel MinValueFieldItemViewModel { get; protected set; }

        #endregion

        #region Methods

        public static DateTimeMetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new DateTimeMetaFieldTemplateEditionPanelViewModel());
        }

        public override void Initialize(IDateTimeMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaDateTimeMetaField = EntityService.GetMetaEntity(nameof(IDateTimeMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaDateTimeMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeDateTimeMetaField(metaDateTimeMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IDateTimeMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<DateTime?>(nameof(IIntegerMetaField.MinValue));
            MinValueFieldItemViewModel = DateFieldItemViewModel.Create(fieldValidator, Entity, metaField.MinValue);
            EditableItemsFields.Add(MinValueFieldItemViewModel);
            fieldValidator = GetFieldValidator<DateTime?>(nameof(IIntegerMetaField.MaxValue));
            MaxValueFieldItemViewModel = DateFieldItemViewModel.Create(fieldValidator, Entity, metaField.MaxValue);
            fieldValidator = GetFieldValidator<DateTime?>(nameof(IIntegerMetaField.DefaultValue));
            EditableItemsFields.Add(MaxValueFieldItemViewModel);
            DefaultValueFieldItemViewModel =
                DateFieldItemViewModel.Create(fieldValidator, Entity, metaField.DefaultValue);
            EditableItemsFields.Add(DefaultValueFieldItemViewModel);
        }

        #endregion
    }
}