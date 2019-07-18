using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;
namespace Sqi.MdManager.Application.Core.ViewModels.Items
{
    [POCOViewModel]
    public class MetaFieldItemTemplateViewModel : ViewModelBase, IEntityItemViewModel
    {
        #region Properties

        public string DisplayLabel => MetaFieldTemplate.Label;
        public IMetaField MetaFieldTemplate => Value as IMetaField;
        public IEntity Value { get; }

        #endregion

        #region Constructors

        protected MetaFieldItemTemplateViewModel(IMetaField metaFieldTemplate) => Value = metaFieldTemplate;

        #endregion

        #region Methods

        public static MetaFieldItemTemplateViewModel Create(IMetaField metaFieldTemplate)
        {
            return ViewModelSource.Create(() => new MetaFieldItemTemplateViewModel(metaFieldTemplate));
        }

        #endregion
    }
}
