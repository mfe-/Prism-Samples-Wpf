using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism_Concepts_Infrastructure;

namespace Prism_Concepts_UserControls
{
    /// <summary>
    /// Interaction logic for WelcomeControl.xaml
    /// </summary>
    [ViewExport(RegionName = "ShellContent")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class WelcomeControl : UserControl
    {
        public WelcomeControl()
        {
            InitializeComponent();
        }
    }
}
