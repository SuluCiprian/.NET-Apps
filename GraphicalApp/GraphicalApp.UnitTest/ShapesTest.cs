using GraphicalApp.Circle;
using GraphicalApp.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicalApp.UnitTest
{
    [TestClass]
    public class ShapesTest
    {
        IShapePlugin shapePlugin = null;
        private double radius = 10;
        private Point center;
        //IShapePlugin expectedResult = new ShapesGroupPlugin();
        double expectedArea = 12;

        [TestInitialize]
        public void InitializeTest()
        {
            shapePlugin = new CirclePlugin();
        }

        [TestMethod]
        public void TestCircleArea()
        {
            IShape shape = shapePlugin.GetShape();
            Assert.IsNotNull(shape);
            Assert.AreEqual(expectedArea, shape.Area());

        }
      
    }
}
