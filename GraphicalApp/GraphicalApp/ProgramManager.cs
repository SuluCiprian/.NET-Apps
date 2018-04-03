using System;
using System.Collections.Generic;
using System.Text;
using GraphicalApp.Shared;
using GraphicalApp.ShapesGroup;

namespace GraphicalApp
{
    public class ProgramManager
    {
        private ConsoleMenu consoleMenu;
        private Canvas canvas;

        PluginsManager<IShapePlugin> shapesPluginManager = new PluginsManager<IShapePlugin>();

        public ProgramManager()
        {
            consoleMenu = new ConsoleMenu();
            canvas = new Canvas();
        }

        private void HandlePluginParameters(IShapePlugin plugin)
        {
            List<string> arguments = (List<string>)plugin.GetRequiredArguments();
            if (arguments.Count != 0)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                Console.WriteLine("Enter parameters: ");
                foreach (var arg in arguments)
                {
                    Console.WriteLine(arg + ": ");
                    parameters[arg] = Console.ReadLine();
                }
                plugin.SetArguments(parameters);
            }
        }

        public void Initialize()
        {
            shapesPluginManager.LoadPlugins(@"E:\GraphicalApp");
            char optionNo = '1';
            foreach (var shapePlugin in shapesPluginManager.Plugins)
            {
                consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = shapePlugin.GetName(), ContextObject = shapePlugin, ItemAction = new MenuItemAction(Action) });
                optionNo++;
            }
            consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = "Add to group", ContextObject = new ShapesGroupPlugin(), ItemAction = new MenuItemAction(AddAction) });
        }

        public void RunApp()
        {
            consoleMenu.Run();
        }

        public void Action(object sender, object contextObject)
        {
            IShapePlugin shapePlugin = (IShapePlugin)contextObject;
            HandlePluginParameters(shapePlugin);
            IShape shape = shapePlugin.GetShape();
            canvas.AddShape(shape);
            Console.WriteLine("Shapes on canvas:");
            canvas.DrawShapes();
            Console.ReadKey();
        }

        public void AddAction(object sender, object contextObject)
        {
            ShapesGroupPlugin shapePlugin = (ShapesGroupPlugin)contextObject;
            HandlePluginParameters(shapePlugin);
            IShape shape = shapePlugin.GetShape();
            
            foreach (var item in canvas.ShapesOnCanvas)
            {
                if (item.Identifier == shape.Identifier)
                {
                    shapePlugin.AddToGroup(item);
                    break;
                }
            }
        }
    }
}
