using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;

namespace RibbonBuilder
{
    public class PluginBuilder
    {
        public readonly string AssemblyPath;
        
        private readonly string _tabName;
        private readonly UIControlledApplication _application;

        private IEnumerable<RibbonPanel> _ribbonPanels;
        public PluginBuilder(string tabName, UIControlledApplication application, string assemblyPath)
        {
            AssemblyPath = assemblyPath;
            
            _tabName = tabName;
            _application = application;
            
            _application.CreateRibbonTab(_tabName);

            _ribbonPanels = new List<RibbonPanel>();
        }
        
        public bool Build(RibbonPanels ribbonPanels)
        {
            _ribbonPanels = ribbonPanels.CreatePanels(this);
            return _ribbonPanels.Any();
        }
        
        internal RibbonPanel CreateRibbonPanel(string panelName, IEnumerable<RibbonItemData> ribbonItems)
        {
            var ribbonPanel = _application.CreateRibbonPanel(_tabName, panelName);
            foreach (var ribbonItemData in ribbonItems)
            {
                ribbonPanel.AddItem(ribbonItemData);
            }

            return ribbonPanel;
        }
    }
}