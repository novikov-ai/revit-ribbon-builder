# Ribbon Builder

---

## Content

- [CommandBase](https://github.com/novikov-ai/revit-ribbon-builder/tree/main/RibbonBuilder/CommandBase)
    - Get acquainted with Basic Command way [here](https://github.com/novikov-ai/revit-basic-command)
    
- [PluginBuilder](https://github.com/novikov-ai/revit-ribbon-builder/blob/main/RibbonBuilder/PluginBuilder.cs)
    - PluginBuilder could help you create a Revit Ribbon easily with 2 lines of code

- [RibbonPanels](https://github.com/novikov-ai/revit-ribbon-builder/blob/main/RibbonBuilder/RibbonPanels.cs)
    - Create your class of plugin's panels and inherit it from RibbonPanels interface.
  
- [Examples](https://github.com/novikov-ai/revit-ribbon-builder/tree/main/RibbonBuilder/Examples)
    - How it works you could find in examples.

---

### All you need is 2 lines of code (!) and a cozy class with your panels

#### Examples/App.cs
~~~
...

namespace RibbonBuilder.Examples
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;

            // To create your ribbon just provide Tab name and RibbonPanels instance. 
            
            var pluginBuilder = new PluginBuilder("Custom tab name", application, assemblyPath);
            pluginBuilder.Build(new CustomPanels());

            ...
        }
        
        ...
    }
}
~~~
#### Examples/CustomPanels.cs

~~~
...

namespace RibbonBuilder.Examples
{
    public class CustomPanels : RibbonPanels
    {
        public IEnumerable<RibbonPanel> CreatePanels(PluginBuilder builder)
        {
            return new List<RibbonPanel>
            {
                // Your custom ribbon panel needs 2 things:
                // 1) Panel name
                // 2) ExternalCommand instance (inherit from Command)
                
                builder.CreateRibbonPanel("Optimizing", new List<RibbonItemData>
                {
                    RibbonItemFactories.PushButton.Create(builder.AssemblyPath, new CleanUp()),
                }),
                
                ...
                
                // If you need more panels just create them nearby (inside returning list).
            };
        }
    }
}
~~~