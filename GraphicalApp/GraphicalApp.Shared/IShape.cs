using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.Shared
{
    public interface IShape
    {
        void Draw();
        double Area();
        int Identifier { get; set; } 
    }
}
