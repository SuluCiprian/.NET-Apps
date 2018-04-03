using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.Circle
{
    public class CirclePlugin : IShapePlugin
    {
        private double radius;
        private Point center;
        List<string> arguments = new List<string>();

        public CirclePlugin()
        {
            arguments.Add("radius");
            arguments.Add("center.X");
            arguments.Add("center.Y");
        }

        public string GetName()
        {
            Circle circle = (Circle)GetShape();
            return circle.Name;
        }

        public IEnumerable<string> GetRequiredArguments()
        {
            return arguments;
        }

        public IShape GetShape()
        {
            return new Circle(radius, center);
        }

        public void SetArguments(IDictionary<string, string> args)
        {
            radius = Double.Parse(args["radius"]);
            center = new Point();
            center.X = Double.Parse(args["center.X"]);
            center.Y = Double.Parse(args["center.Y"]);
        }
    }
}
