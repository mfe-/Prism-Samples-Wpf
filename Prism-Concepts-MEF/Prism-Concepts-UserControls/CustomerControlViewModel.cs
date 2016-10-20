using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using Prism.Regions;

namespace Prism_Concepts_UserControls
{
    [Export]
    public class CustomerControlViewModel : Prism.Mvvm.BindableBase, IInteractionRequestAware
    {
        private IRegionManager _IRegionManager;
        [ImportingConstructor]
        public CustomerControlViewModel(IRegionManager regionManager, ILoggerFacade log)
        {
            _IRegionManager = regionManager;
            OkCommand = new DelegateCommand(OnOkCommand);
            MoveCommand = new DelegateCommand(OnMoveCommand);
        }

        public DelegateCommand OkCommand { get; private set; }

        private void OnOkCommand()
        {
            if (_Notification == null) return;
            _Notification.Confirmed = true;
            _Notification.Content = new Point(1,2);
            FinishInteraction();
        }

        /// <summary>
        /// Get or sets the callback for the popup window
        /// </summary>
        public Action FinishInteraction { get; set; }

        private Confirmation _Notification;
        /// <summary>
        /// Get or sets the notification
        /// </summary>
        public INotification Notification
        {
            get
            {
                return _Notification;
            }

            set
            {
                _Notification = value as Confirmation;
                OnPropertyChanged(() => Notification);
            }
        }

        public DelegateCommand MoveCommand { get; set; }

        private void OnMoveCommand()
        {
            _IRegionManager.RequestNavigate("ShellContent", new Uri("/WelcomeControl", UriKind.Relative));
        }
    }
}
