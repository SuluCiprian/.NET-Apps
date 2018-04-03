using System;
using System.Collections.Generic;
using GraphicalApp.Shared;
using System.Text;

namespace GraphicalApp.Square
{
    class Square: IShape
    {
        private int identifier;
        private Point A;
        private Point B;
        private Point C;
        private Point D;
        private string name = "Square";
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Identifier { get => identifier; set => identifier = value; }

        public Square(Point A, Point B, Point C, Point D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }

        public double Area()
        {
            double AB = Math.Sqrt((B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y));
            return AB * AB;
        }

        public void Draw()
        {
            Console.WriteLine(name + " A=" + A.GetPoint() + " B=" + B.GetPoint() + " C=" + C.GetPoint() + " D=" + C.GetPoint() + " Identifier=" + identifier + " Area=" + Area());
        }
    }
}
