using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.Shared
{
    public class Point
    {
        public double X { set; get; }
        public double Y { set; get; }
        public string GetPoint()
        {
            return "(" + X + "," + Y + ")";
        }

    }
}
