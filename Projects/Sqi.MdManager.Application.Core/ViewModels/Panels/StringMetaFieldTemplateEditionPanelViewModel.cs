using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;
using Sqi.MdManager.Application.Core.ViewModels.Items;
using System.Linq;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class StringMetaFieldTemplateEditionPanelViewModel : MetaFieldEditionPanelViewModel<IStringMetaField>
    {
        #region Properties

        public virtual TextBoxFieldItemViewModel DefaultValueFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel DisplayedLinesCountFieldItemViewModel { get; protected set; }
        public virtual EntityFieldItemViewModel EntityRegularExpressionFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MaxLengthFieldItemViewModel { get; protected set; }
        public virtual TextBoxFieldItemViewModel MinLengthFieldItemViewModel { get; protected set; }
        #endregion

        #region Methods

        public static StringMetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new StringMetaFieldTemplateEditionPanelViewModel());
        }

        public override void Initialize(IStringMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaStringMetaField = EntityService.GetMetaEntity(nameof(IStringMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaStringMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeStringMetaField(metaStringMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IStringMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<int?>(nameof(IStringMetaField.MinLength));
            MinLengthFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.MinLength.ToString());
            EditableItemsFields.Add(MinLengthFieldItemViewModel);
            fieldValidator = GetFieldValidator<int?>(nameof(IStringMetaField.MaxLength));
            MaxLengthFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.MaxLength.ToString());
            EditableItemsFields.Add(MaxLengthFieldItemViewModel);
            fieldValidator = GetFieldValidator<int?>(nameof(IStringMetaField.DisplayedLinesCount));
            DisplayedLinesCountFieldItemViewModel = TextBoxFieldItemViewModel.Create(fieldValidator, Entity,
                metaField.DisplayedLinesCount.ToString());
            EditableItemsFields.Add(DisplayedLinesCountFieldItemViewModel);
            fieldValidator = GetFieldValidator<string>(nameof(IStringMetaField.DefaultValue));
            DefaultValueFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.DefaultValue);
            EditableItemsFields.Add(DefaultValueFieldItemViewModel);
            fieldValidator = GetFieldValidator<IEntity>(nameof(IStringMetaField.RegularExpression));
            var regularExpressions = MetaDataService.GetRegularExpressions().OrderBy(me => me.Label).ToList();
            var regularExpressionViewModels = regularExpressions.Select(RegularExpressionItemViewModel.Create);
            EntityRegularExpressionFieldItemViewModel =
                EntityFieldItemViewModel.Create(fieldValidator, Entity,
                regularExpressionViewModels, metaField.RegularExpression);
            EditableItemsFields.Add(EntityRegularExpressionFieldItemViewModel);
        }

        #endregion
    }
}