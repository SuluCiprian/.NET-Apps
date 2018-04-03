using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp.ShapesGroup
{
    public class ShapesGroup: IShape
    {
        private string name = "ShapesGroup";
        private int identifier;
        private List<IShape> groupShapes = new List<IShape>();
        public List<IShape> GroupSahpes
        {
            get
            {
                return groupShapes;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Identifier { get => identifier; set => identifier = value; }

        public void AddToGroup(IShape shape)
        {
            groupShapes.Add(shape);
        }
        

        public double Area()
        {
            double totalArea = 0;
            foreach (var shape in groupShapes)
            {
                totalArea += shape.Area();
            }
            return totalArea;
        }

        public void Draw()
        {
            Console.WriteLine(name);
            foreach (var shape in groupShapes)
            {
                shape.Draw();
            }
            Console.WriteLine("Total area: " + Area());
        }

    }
}
