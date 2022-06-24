using System.Collections.Generic;
using Autodesk.Revit.UI;
using RibbonBuilder.Examples.Optimizing;
using RibbonBuilder.Examples.Reports;
using RibbonBuilder.Examples.SharedParameters;

namespace RibbonBuilder.Examples
{
    public class CustomPanels : RibbonPanels
    {
        public IEnumerable<RibbonPanel> CreatePanels(PluginBuilder builder)
        {
            return new List<RibbonPanel>
            {
                builder.CreateRibbonPanel("Optimizing", new List<RibbonItemData>
                {
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new CleanUp()),
                }),

                builder.CreateRibbonPanel("Reports", new List<RibbonItemData>
                {
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new ModelChecker()),
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new ReportViewer()),
                }),
                builder.CreateRibbonPanel("Shared parameters", new List<RibbonItemData>
                {
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new ParamsLoader()),
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new ParamsChecker()),
                })
            };
        }
    }
}