using System.Reflection;
using Autodesk.Revit.UI;

namespace RibbonBuilder.Examples
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;

            var pluginBuilder = new PluginBuilder("Custom tab name", application, assemblyPath);
            pluginBuilder.Build(new CustomPanels());

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}