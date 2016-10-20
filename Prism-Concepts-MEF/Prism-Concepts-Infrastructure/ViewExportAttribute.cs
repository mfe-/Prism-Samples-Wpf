using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Concepts_Infrastructure
{
    /// <summary>
    /// Exports the view with the RegionName. Exported views with this class will be automaticly added the the proper region when using <see cref="AutoPopulateExportedViewsBehavior"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public sealed class ViewExportAttribute : ExportAttribute, IViewRegionRegistration
    {
        public ViewExportAttribute()
            : base(typeof(object))
        {

        }

        public ViewExportAttribute(string viewName)
            : base(viewName, typeof(object))
        {

        }

        public string ViewName { get { return base.ContractName; } }

        public string RegionName { get; set; }
    }
}
