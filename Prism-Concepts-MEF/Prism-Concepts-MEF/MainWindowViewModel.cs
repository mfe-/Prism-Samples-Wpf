using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace Prism_Concepts_MEF
{
    [Export]
    public class MainWindowViewModel : Prism.Mvvm.BindableBase
    {
        protected readonly IWebService _IWebService;
        [ImportingConstructor]
        public MainWindowViewModel(IWebService webService, Prism.Logging.ILoggerFacade logger)
        {
            _IWebService = webService;
            MessageCommand = new DelegateCommand(OnMessageCommand);

            MessageControlInteraction = new InteractionRequest<IConfirmation>();
        }

        public DelegateCommand MessageCommand { get; set; }

        protected void OnMessageCommand()
        {
            //System.Windows.MessageBox.Show("You Clicked me");
            MessageControlInteractionRaise();
        }

        public InteractionRequest<IConfirmation> MessageControlInteraction { get; private set; }

        protected void MessageControlInteractionRaise()
        {
            MessageControlInteraction.Raise(new Confirmation() { Title = "User" }, OnMessageControlInteractionRequest);
        }

        protected void OnMessageControlInteractionRequest(IConfirmation conformation)
        {
            if (conformation.Confirmed)
            {
                System.Windows.MessageBox.Show(conformation.Content.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("Canceld Dialog");
            }
        }
    }
}
