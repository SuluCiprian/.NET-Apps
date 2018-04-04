using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.Circle
{
    public class Circle: IShape
    {
        private int identifier;
        private double radius;
        private Point center;
        private string name = "Circle";
        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Identifier { get =>  identifier; set => identifier = value; }

        public Circle (double radius, Point center)
        {
            this.radius = radius;
            this.center = center;
        }


        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public void Draw()
        {
            Console.WriteLine(name + "->" + " Raza=" + radius + " Centrul cercului=" + center.GetPoint() + " Identifier=" + identifier + " Area=" + Area());
        }
        
    }
}
