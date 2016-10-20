using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

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
        }

        public DelegateCommand MessageCommand { get; set; }

        protected void OnMessageCommand()
        {
            System.Windows.MessageBox.Show("You Clicked me");
        }
    }
}
