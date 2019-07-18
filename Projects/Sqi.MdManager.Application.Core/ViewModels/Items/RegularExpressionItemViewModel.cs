using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Sqi.Framework.Application.ViewModels.Items;
using Sqi.Framework.Models;

namespace Sqi.MdManager.Application.Core.ViewModels.Items
{
    [POCOViewModel]
    public class RegularExpressionItemViewModel : ViewModelBase, IEntityItemViewModel
    {
        #region Properties

        public string DisplayLabel => RegularExpression.Label;
        public IRegularExpression RegularExpression => Value as IRegularExpression;
        public IEntity Value { get; }

        #endregion

        #region Constructors

        protected RegularExpressionItemViewModel(IRegularExpression regularExpression) => Value = regularExpression;

        #endregion

        #region Methods

        public static RegularExpressionItemViewModel Create(IRegularExpression regularExpression)
        {
            return ViewModelSource.Create(() => new RegularExpressionItemViewModel(regularExpression));
        }

        #endregion
    }
}