using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalApp
{
    public class Canvas
    {
        private List<IShape> shapesOnCanvas = new List<IShape>();
        private int identifier = 0;

        public void AddShape(IShape shape)
        {
            shape.Identifier = identifier++; 
            shapesOnCanvas.Add(shape);
        }

        public void DrawShapes()
        {
            foreach (var shape in shapesOnCanvas)
            {
                shape.Draw();
            }
        }
    }
}
