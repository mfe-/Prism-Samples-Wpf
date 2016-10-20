using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
