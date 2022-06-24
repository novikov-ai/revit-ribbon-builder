using System.Collections.Generic;
using Autodesk.Revit.UI;

namespace RibbonBuilder
{
    public interface RibbonPanels
    {
        public IEnumerable<RibbonPanel> CreatePanels(PluginBuilder builder);
    }
}