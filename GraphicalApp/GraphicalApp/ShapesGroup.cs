using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp
{
    class ShapesGroup
    {
        private string name;
        private List<IShape> groupShpes = new List<IShape>();

        public ShapesGroup(string name)
        {
            this.name = name;
        }

        public void AddToGroup(IShape shape)
        {
            groupShpes.Add(shape);
        }
        public void DrawGroupShapes()
        {
            foreach (var shape in groupShpes)
            {
                shape.Draw();
            }
        }

    }
}
