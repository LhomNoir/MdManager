using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;
using Sqi.MdManager.Application.Core.ViewModels.Items;
using System.Linq;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    public class EntityMetaFieldTemplateEditionPanelViewModel : MetaFieldEditionPanelViewModel<IEntityMetaField>
    {
        #region Properties

        public virtual TextBoxFieldItemViewModel DefaultValueIdFieldItemViewModel { get; set; }

        #endregion

        #region Methods
        public bool CanOpenMetaFieldTemplatePanel()
        {
            if (MetaFieldTemplateItemViewModel?.SelectedValue.Value != null)
            {
                return true;
            }
            return false;
        }


        public static EntityMetaFieldTemplateEditionPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new EntityMetaFieldTemplateEditionPanelViewModel());
        }

        public override void Initialize(IEntityMetaField metaField, IMetaEntity metaEntity = null)
        {
            var metaEntityMetaField = EntityService.GetMetaEntity(nameof(IEntityMetaField));
            EntityValidator = EntityService.GetEntityValidator(metaEntityMetaField);
            if (metaField == null)
            {
                metaField = MetaDataService.InitializeEntityMetaField(metaEntityMetaField, metaEntity);
            }
            Caption = EntityValidator.MetaEntity.Label;
            Entity = metaField;

            InitializeFieldValidators(metaField);
        }

        protected override void InitializeFieldValidators(IEntityMetaField metaField)
        {
            base.InitializeFieldValidators(metaField);

            IFieldValidator fieldValidator = GetFieldValidator<int?>(nameof(IEntityMetaField.DefaultValueId));
            DefaultValueIdFieldItemViewModel =
                TextBoxFieldItemViewModel.Create(fieldValidator, Entity, metaField.DefaultValueId.ToString());
            EditableItemsFields.Add(DefaultValueIdFieldItemViewModel);
            fieldValidator = GetFieldValidator<IEntity>(nameof(IEntityMetaField.ValueType));
            var metaEntities = MetaDataService.GetMetaEntities().OrderBy(me => me.Label).ToList();
            var metaEntityViewModels = metaEntities.Select(MetaEntityItemViewModel.Create);
            var metaEntity = metaEntities.SingleOrDefault(me => me.Id == metaField.ValueType?.Id);
            ValueTypeFieldItemViewModel =
                EntityFieldItemViewModel.Create(fieldValidator, Entity, metaEntityViewModels, metaEntity);
            EditableItemsFields.Add(ValueTypeFieldItemViewModel);
        }

        #endregion
    }
}