using System;
using System.Collections.Generic;
using System.Text;
using GraphicalApp.Shared;

namespace GraphicalApp.Square
{
    public class SquarePlugin : IShapePlugin
    {
        private Point A = new Point();
        private Point B = new Point();
        private Point C = new Point();
        private Point D = new Point();
        List<string> arguments = new List<string>();

        public SquarePlugin()
        {
            arguments.Add("A.X");
            arguments.Add("A.Y");

            arguments.Add("B.X");
            arguments.Add("B.Y");

            arguments.Add("C.X");
            arguments.Add("C.Y");

            arguments.Add("D.X");
            arguments.Add("D.Y");
        }

        public string GetName()
        {
            Square square = (Square)GetShape();
            return square.Name;
        }

        public IEnumerable<string> GetRequiredArguments()
        {
            return arguments;
        }

        public IShape GetShape()
        {
            return new Square(A, B, C, D);
        }

        public void SetArguments(IDictionary<string, string> args)
        {
            A = new Point();
            B = new Point();
            C = new Point();
            D = new Point();

            A.X = Double.Parse(args["A.X"]);
            A.Y = Double.Parse(args["A.Y"]);

            B.X = Double.Parse(args["B.X"]);
            B.Y = Double.Parse(args["B.Y"]);

            C.X = Double.Parse(args["C.X"]);
            C.Y = Double.Parse(args["C.Y"]);

            D.X = Double.Parse(args["D.X"]);
            D.Y = Double.Parse(args["D.Y"]);
        }
    }
}
