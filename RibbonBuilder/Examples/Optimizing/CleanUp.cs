using Autodesk.Revit.UI;

namespace RibbonBuilder.Examples.Optimizing
{
    public class CleanUp: CommandBase.Command
    {
        public override string Name => "<name>";
        public override string Description => "<description>";
        public override string Picture => "<path>";
        public override string Version => "<version>";

        protected override void RunFunc(ExternalCommandData commandData)
        {
            // implement your logic here
        }
    }
}