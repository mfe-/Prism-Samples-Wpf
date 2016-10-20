using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Concepts_MEF
{
    public class WebService : IWebService
    {
        public string Name
        {
            get
            {
                return ToString();
            }

            set
            {
                ;
            }
        }
    }
}
