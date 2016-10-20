using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Regions;
using Prism_Concepts_Infrastructure;
using Prism_Concepts_UserControls;

namespace Prism_Concepts_MEF
{
    public class MyBootstrapper : Prism.Mef.MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new MainWindow();
        }

        protected override void InitializeShell()
        {
            (Shell as Window).Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(CustomerControl).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.ComposeExportedValue<IWebService>(new WebService());
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
            return factory;
        }
    }
}
