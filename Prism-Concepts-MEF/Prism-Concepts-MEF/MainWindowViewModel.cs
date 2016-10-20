using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
