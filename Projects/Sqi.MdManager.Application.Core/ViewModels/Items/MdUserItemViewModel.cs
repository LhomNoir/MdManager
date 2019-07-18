using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;

namespace Sqi.MdManager.Application.Core.ViewModels.Items
{
    [POCOViewModel]
    public class MdUserItemViewModel : ViewModelBase, IEntityItemViewModel
    {
        #region Properties

        public string DisplayLabel => MdUser.Login;
        public IMdUser MdUser => Value as IMdUser;
        public IEntity Value { get; }

        #endregion

        #region Constructors

        protected MdUserItemViewModel(IMdUser mdUser) => Value = mdUser;

        #endregion

        #region Methods

        public static MdUserItemViewModel Create(IMdUser mdUser)
        {
            return ViewModelSource.Create(() => new MdUserItemViewModel(mdUser));
        }

        #endregion
    }
}