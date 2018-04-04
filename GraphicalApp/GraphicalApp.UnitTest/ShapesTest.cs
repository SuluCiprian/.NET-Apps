using GraphicalApp.Circle;
using GraphicalApp.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraphicalApp.UnitTest
{
    [TestClass]
    public class ShapesTest
    {
        GraphicalApp.Circle.Circle circle = null;
        GraphicalApp.Square.Square square = null;
        GroupShapes group = null;
        private double radius = 10;
        private Point center = new Point();
        private Point A = new Point();
        private Point B = new Point();
        private Point C = new Point();
        private Point D = new Point();
        double expectedCircleArea = 314.159265358979;
        double expectedSquareArea = 9;
        double expectedGroupArea = 314.159265358979 + 9;


        [TestInitialize]
        public void InitializeTest()
        {
            center.X = 1;
            center.Y = 2;
            circle = new GraphicalApp.Circle.Circle(radius, center);

            A.X = 3;
            A.Y = 2;
            B.X = 6;
            B.Y = 2;
            C.X = 6;
            C.Y = 5;
            D.X = 3;
            D.Y = 5;
            square = new GraphicalApp.Square.Square(A, B, C, D);
            group = new GroupShapes();
        }

        [TestMethod]
        public void TestCircleArea()
        {
            double computedTest = expectedCircleArea - circle.Area();
            Assert.AreEqual(computedTest < Double.Epsilon, true);
        }

        [TestMethod]
        public void TestSquareArea()
        {

            double computedTest = expectedSquareArea - square.Area();
            Assert.AreEqual(computedTest < Double.Epsilon, true);

        }

        [TestMethod]
        public void TestGroupArea()
        {
            center.X = 1;
            center.Y = 2;

            group.AddToGroup(circle);
            group.AddToGroup(square);
            double computedTest = expectedGroupArea - group.Area();
            Assert.AreEqual(computedTest < Double.Epsilon, true);
        }

    }
}
