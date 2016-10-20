using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;

namespace Prism_Concepts_Infrastructure
{
    /// <summary>
    /// Checks on a OnImportsSatisfied whether the exported class contains in the metadata a RegionName. If so the class will be registered with the RegionName to the Region.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/gg430861(v=pandp.40).aspx">Navigation in Prism</seealso>
    /// <remarks>
    /// Change Navigation with IRegionManager.RequestNavigate(RegionNames.ShellContent, new Uri("/UserControlOther", UriKind.Relative));
    /// </remarks>
    /// <example>
    /// In your Bootstrapper
    /// protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
    /// {
    ///     var factory = base.ConfigureDefaultRegionBehaviors();
    ///     factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
    ///     return factory;
    /// }
    /// </example>
    /// </summary>
    [Export(typeof(AutoPopulateExportedViewsBehavior))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AutoPopulateExportedViewsBehavior : RegionBehavior, IPartImportsSatisfiedNotification
    {
        protected override void OnAttach()
        {
            AddRegisteredViews();
        }

        public void OnImportsSatisfied()
        {
            AddRegisteredViews();
        }

        private void AddRegisteredViews()
        {
            if (Region != null)
            {
                foreach (var viewEntry in this.RegisteredViews)
                {
                    if (viewEntry.Metadata.RegionName == this.Region.Name)
                    {
                        var view = viewEntry.Value;

                        if (!this.Region.Views.Contains(view))
                        {
                            this.Region.Add(view);
                            OnNewViewEvent(view);
                        }
                    }
                }
            }
        }

        public event EventHandler<object> NewViewEvent;

        protected virtual void OnNewViewEvent(object view)
        {
            EventHandler<object> newviewHandler = NewViewEvent;
            if (newviewHandler != null)
            {
                newviewHandler(this, view);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "MEF injected values"), ImportMany(AllowRecomposition = false)]
        public Lazy<object, IViewRegionRegistration>[] RegisteredViews { get; set; }
    }
}
