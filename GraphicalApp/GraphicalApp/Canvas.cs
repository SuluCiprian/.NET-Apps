using GraphicalApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicalApp
{
    public class Canvas
    {
        private List<IShape> shapesOnCanvas = new List<IShape>();
        private int identifier = 0;

        private IShape GetShapeById(int id)
        {
            IShape retVal = null;
            var shapesList = shapesOnCanvas.Where(shape => shape.Identifier == id);
            if (shapesList.Count() > 0)
            {
                retVal = shapesList.First();
            }

            return retVal;
        }
        public List<IShape> ShapesOnCanvas
        {
            get
            {
                return shapesOnCanvas;
            }
        }

        public void AddShape(IShape shape)
        {
            shape.Identifier = identifier++; 
            shapesOnCanvas.Add(shape);
        }


        public void AddShapeToGroup(int shapeId, int groupId)
        {
            IShape shapeToAdd = GetShapeById(shapeId);
            if (shapeToAdd != null)
            {
                GroupShapes group = (GroupShapes)GetShapeById(groupId);
                group.AddToGroup(shapeToAdd);
                shapesOnCanvas.Remove(shapeToAdd);
            }
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
