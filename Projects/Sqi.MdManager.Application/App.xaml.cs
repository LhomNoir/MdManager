using System.Windows;
using DevExpress.Xpf.Core;
using Sqi.Framework;
using Sqi.Framework.Models;
using Sqi.Framework.Models.Core;
using Sqi.Framework.Repositories;
using Sqi.Framework.Repositories.Core;
using Sqi.Framework.Services;
using Sqi.Framework.Services.Core;
using Sqi.MdManager.Services;
using Sqi.MdManager.Services.Core;

namespace Sqi.MdManager.Application
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationThemeHelper.UpdateApplicationThemeName();

            InitializeInstances();
        }

        private void InitializeInstances()
        {
            var locator = InstanceLocator.Current;

            locator.RegisterInstance<IModelFactory, ModelFactory>();
            locator.RegisterInstance<IMetaModelRepository, MetaModelRepository>();
            locator.RegisterInstance<IEntityService, EntityService>();
            locator.RegisterInstance<IMetaDataService, MetaDataService>();
        }

        #endregion
    }
}