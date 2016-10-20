using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism_Concepts_UserControls
{
    [Export]
    public class WelcomeControlViewModel : BindableBase
    {
        private IRegionManager _IRegionManager;
        [ImportingConstructor]
        public WelcomeControlViewModel(IRegionManager regionManager)
        {
            _IRegionManager = regionManager;
            MoveCommand = new DelegateCommand(OnMoveCommand);
        }

        public DelegateCommand MoveCommand { get; set; }

        private void OnMoveCommand()
        {
            _IRegionManager.RequestNavigate("ShellContent", new Uri("/CustomerControl", UriKind.Relative));
        }
    }
}
