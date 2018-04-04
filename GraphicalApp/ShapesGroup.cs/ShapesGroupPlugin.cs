using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.ShapesGroup
{
    public class ShapesGroupPlugin : IShapePlugin
    {
        private int identifier;
        private string name;
        List<string> arguments = new List<string>();

        public ShapesGroupPlugin()
        {
            arguments.Add("identifier");
            arguments.Add("name");
        }

        public string GetName()
        {
            return "Group Shape";
        }

        public IEnumerable<string> GetRequiredArguments()
        {
            return arguments;
        }

        public IShape GetShape()
        {
            return new ShapesGroup(name, identifier);
        }

        public void SetArguments(IDictionary<string, string> args)
        {
            identifier = Int32.Parse(args["identifier"]);
            name = args["name"];
            
        }
        //public void AddToGroup(IShape shape)
        //{
        //    ShapesGroup group = (ShapesGroup)GetShape();
        //    group.AddToGroup(shape);
        //}

        //public List<IShape> GetGroupShapes()
        //{
        //    ShapesGroup group = (ShapesGroup)GetShape();
        //    return group.GroupSahpes;
        //}
    }
}
