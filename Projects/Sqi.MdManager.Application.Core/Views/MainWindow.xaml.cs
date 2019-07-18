using DevExpress.Xpf.Docking.Base;

namespace Sqi.MdManager.Application.Core.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            DockLayoutManager.DockItemClosing += DockLayoutManager_OnDockItemClosing;
        }

        #endregion

        #region Methods

        private void DockLayoutManager_OnDockItemClosed(object sender, DockItemClosedEventArgs e)
        {
            e.Item.Closed = true;
        }

        private void DockLayoutManager_OnDockItemClosing(object sender, ItemCancelEventArgs e)
        {
            e.Item.Closed = true;
        }

        #endregion
    }
}