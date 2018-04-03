using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp
{
    class ShapesGroup: IShape
    {
        private string name;
        private int identifier;
        private List<IShape> groupShpes = new List<IShape>();

        public ShapesGroup(string name)
        {
            this.name = name;
        }

        public int Identifier { get => identifier; set => identifier = value; }

        public void AddToGroup(IShape shape)
        {
            groupShpes.Add(shape);
        }

        public double Area()
        {
            return 0;
        }

        public void Draw()
        {
            foreach (var shape in groupShpes)
            {
                shape.Draw();
            }
        }

    }
}
