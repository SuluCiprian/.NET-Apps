using System;
using System.Collections.Generic;
using GraphicalApp.Shared;
using System.Text;

namespace GraphicalApp.Triangle
{
    class Triangle: IShape
    {
        private string name = "Triangle";
        public int Identifier { set; get; }
        public Point A { set; get; }
        public Point B { set; get; }
        public Point C { set; get; }

        public double Area()
        {
            return 1.0;
        }

        public void Draw()
        {
            Console.WriteLine(name + " A=" + A.GetPoint() + " B=" + B.GetPoint() + " C=" + C.GetPoint() + " Identifier=" + Identifier + " Area=" + Area());
        }
    }
}
