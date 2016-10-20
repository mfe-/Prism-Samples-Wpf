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

namespace Prism_Concepts_UserControls
{
    [Export]
    public class CustomerControlViewModel : Prism.Mvvm.BindableBase, IInteractionRequestAware
    {
        [ImportingConstructor]
        public CustomerControlViewModel(ILoggerFacade log)
        {
            OkCommand = new DelegateCommand(OnOkCommand);
        }

        public DelegateCommand OkCommand { get; private set; }

        private void OnOkCommand()
        {
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
    }
}
