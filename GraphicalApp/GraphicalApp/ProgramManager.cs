using System;
using System.Collections.Generic;
using System.Text;
using GraphicalApp.Shared;

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
            consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = "Add group", ContextObject = null, ItemAction = new MenuItemAction(GroupAction) });
            optionNo++;
            consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = "Add to group", ContextObject = new GroupShapes(), ItemAction = new MenuItemAction(AddAction) });
            optionNo++;
            consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = "Display canvas", ContextObject = null, ItemAction = new MenuItemAction(CanvasAction) });
            
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

        public void GroupAction(object sender, object contextObject)
        {
            //GroupShapes group = (GroupShapes)contextObject;
            GroupShapes group = new GroupShapes();
            //Console.WriteLine("Identifier: ");
            //group.Identifier = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Group name:");
            group.GroupName = Console.ReadLine();

            canvas.AddShape(group);
            Console.WriteLine("Shapes on canvas:");
            canvas.DrawShapes();
            Console.ReadKey();
        }

        public void CanvasAction(object sender, object contextObject)
        {
            Console.WriteLine("Shapes on canvas:");
            canvas.DrawShapes();
            Console.ReadKey();
        }

        public void AddAction(object sender, object contextObject)
        {
            GroupShapes group = (GroupShapes)contextObject;
            Console.WriteLine("Id of the group: ");
            group.Identifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Insert the id of shape: ");
            int id = Int32.Parse(Console.ReadLine());

            foreach (var canvasShape in canvas.ShapesOnCanvas.ToArray())
            {
               
                if (canvasShape.Identifier == group.Identifier)
                {
                    foreach (var item in canvas.ShapesOnCanvas)
                    {
                        if (item.Identifier == id)
                        {
                            GroupShapes groupShape = (GroupShapes)canvasShape;
                            groupShape.AddToGroup(item);
                            canvas.RemoveShape(item);
                            break;
                        }
                    }
                }
            }

            
        }
    }
}
