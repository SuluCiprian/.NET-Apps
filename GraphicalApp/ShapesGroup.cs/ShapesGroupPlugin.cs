using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.ShapesGroup
{
    public class ShapesGroupPlugin : IShapePlugin
    {
        private int identifier;
        List<string> arguments = new List<string>();

        public ShapesGroupPlugin()
        {
            arguments.Add("identifier");
        }

        public string GetName()
        {
            ShapesGroup group = (ShapesGroup)GetShape();
            return group.Name;
        }

        public IEnumerable<string> GetRequiredArguments()
        {
            return arguments;
        }

        public IShape GetShape()
        {
            return new ShapesGroup();
        }

        public void SetArguments(IDictionary<string, string> args)
        {
            identifier = Int32.Parse(args["identifier"]);
            // de mutat
            ShapesGroup group = (ShapesGroup)GetShape();
            foreach (var item in group.GroupSahpes)
            {
                if(item.Identifier == identifier)
                {
                    group.AddToGroup(item);
                    break;
                }
            }
        }
    }
}
