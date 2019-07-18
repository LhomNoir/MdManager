using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework;
using Sqi.Framework.Application.ViewModels.Panels;
using Sqi.Framework.Models;
using Sqi.Framework.Services;
using Sqi.MdManager.Application.Core.Resources;
using Sqi.MdManager.Services;

namespace Sqi.MdManager.Application.Core.ViewModels.Panels
{
    [POCOViewModel]
    public class MetaFieldTemplateListPanelViewModel : EntityListPanelViewModel
    {
        #region Properties 
        public virtual string CreateModelLabel { get; protected set; }
        public virtual string MetaFieldTemplateLabel { get; protected set; }

        public virtual string CreateBooleanMetaFieldTemplateLabel { get; protected set; }
        public virtual string CreateDateTimeMetaFieldTemplateLabel { get; protected set; }
        public virtual string CreateDecimalMetaFieldTemplateLabel { get; protected set; }
        public virtual string CreateEntityMetaFieldTemplateLabel { get; protected set; }
        public virtual string CreateIntegerMetaFieldTemplateLabel { get; protected set; }
        public virtual string CreateStringMetaFieldTemplateLabel { get; protected set; }
        private IEntityService EntityService { get; } = InstanceLocator.Current.GetInstance<IEntityService>();
        private MainViewModel MainViewModel => this.GetParentViewModel<MainViewModel>();
        public EntityListPanelViewModel MetaFieldListPanelViewModel { get; protected set; }
        private IMetaEntity MetaBooleanMetaField { get; set; }
        private IMetaDataService MetaDataService { get; } = InstanceLocator.Current.GetInstance<IMetaDataService>();
        private IMetaEntity MetaDateTimeMetaField { get; set; }
        private IMetaEntity MetaDecimalMetaField { get; set; }

        private IMetaEntity MetaEntity { get; }

        private IMetaEntity MetaEntityMetaField { get; set; }
        private IMetaEntity MetaIntegerMetaField { get; set; }
        private IMetaEntity MetaStringMetaField { get; set; }

        #endregion

        public void CreateBooleanMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeBooleanMetaFieldTemplate(MetaBooleanMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        public void CreateDateTimeMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeDateTimeMetaFieldTemplate(MetaDateTimeMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        public void CreateDecimalMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeDecimalMetaFieldTemplate(MetaDecimalMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        public void CreateEntityMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeEntityMetaFieldTemplate(MetaEntityMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        public void CreateIntegerMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeIntegerMetaFieldTemplate(MetaIntegerMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        public void CreateStringMetaFieldTemplate()
        {
            var metaField = MetaDataService.InitializeStringMetaFieldTemplate(MetaStringMetaField);
            OpenMetaFieldTemplateEdition(metaField);
        }

        private void OpenMetaFieldTemplateEdition(IEntity metaField)
        {
            MainViewModel.OpenMetaFieldTemplateEdition(metaField);
        }

        public MetaFieldTemplateListPanelViewModel()
        {
            if (IsInDesignMode)
            {
                return;
            }

            Initialize();

            GetEntitiesFunction = MetaDataService.GetMetaFieldTemplates;
            OpenCreationAction = null;
            OpenModificationAction = null;
            DeleteAction = null;
            var metaEntityTemplate = EntityService.GetMetaEntity(nameof(IMetaField));
            //EntityValidator = EntityService.GetEntityValidator(metaEntityTemplate);
        }

        public static MetaFieldTemplateListPanelViewModel Create()
        {
            return ViewModelSource.Create(() => new MetaFieldTemplateListPanelViewModel());
        }

        private void Initialize()
        {
            Caption = MdManagerLabels.MetaFieldTemplateLabels;
            CreateModelLabel = MdManagerLabels.CreateTemplateLabel;
            MetaFieldTemplateLabel = MdManagerLabels.MetaFieldTemplateLabel;
            MetaBooleanMetaField = EntityService.GetMetaEntity(nameof(IBooleanMetaField));
            CreateBooleanMetaFieldTemplateLabel = MetaBooleanMetaField.Label;
            MetaIntegerMetaField = EntityService.GetMetaEntity(nameof(IIntegerMetaField));
            CreateIntegerMetaFieldTemplateLabel = MetaIntegerMetaField.Label;
            MetaDecimalMetaField = EntityService.GetMetaEntity(nameof(IDecimalMetaField));
            CreateDecimalMetaFieldTemplateLabel = MetaDecimalMetaField.Label;
            MetaDateTimeMetaField = EntityService.GetMetaEntity(nameof(IDateTimeMetaField));
            CreateDateTimeMetaFieldTemplateLabel = MetaDateTimeMetaField.Label;
            MetaStringMetaField = EntityService.GetMetaEntity(nameof(IStringMetaField));
            CreateStringMetaFieldTemplateLabel = MetaStringMetaField.Label;
            MetaEntityMetaField = EntityService.GetMetaEntity(nameof(IEntityMetaField));
            CreateEntityMetaFieldTemplateLabel = MetaEntityMetaField.Label;
        }
    }
}
