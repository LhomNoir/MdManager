using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;

namespace Sqi.MdManager.Application.Core.ViewModels.Items
{
    [POCOViewModel]
    public class MetaEntityItemViewModel : ViewModelBase, IEntityItemViewModel
    {
        #region Properties

        public string DisplayLabel => MetaEntity?.Label;
        public IMetaEntity MetaEntity => Value as IMetaEntity;
        public IEntity Value { get; }

        #endregion

        #region Constructors

        protected MetaEntityItemViewModel(IMetaEntity metaEntity) => Value = metaEntity;

        #endregion

        #region Methods

        public static MetaEntityItemViewModel Create(IMetaEntity metaEntity)
        {
            return ViewModelSource.Create(() => new MetaEntityItemViewModel(metaEntity));
        }

        #endregion
    }
}