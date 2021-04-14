using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class CovarianceAndContravarianceTest
    {
        [TestMethod]
        public void GetCircleCollectionCountCovarianceTest()
        {
            IFigureCollectionCount<BaseFigure> circles = new CircleCollectionCount<Circle>(new[]
            {
                new Circle(4),
                new Circle(5),
                new Circle(6)
            });
            var message = circles.GetCollectionCount();
            Assert.IsNotNull(message);
        }

        [TestMethod]
        public void PrintFigureInfoContravarianceTest()
        {
            IFigurePrintInfo<Rectangle> figure = new PrintFigureInfo<BaseFigure>();
            figure.PrintInfoThroughEvent(new Rectangle(2, 3));
        }
    }
}
