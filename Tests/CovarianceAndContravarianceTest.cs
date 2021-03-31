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
        public void CircleCollectionCountCovarianceTest()
        {
            IFigureCollectionCount<BaseFigure> circles = new CircleCollectionCount<Circle>(new[]
            {
                new Circle(4),
                new Circle(5),
                new Circle(6)
            });
            var message = circles.CollectionCount();
            Assert.IsNotNull(message);
        }

        [TestMethod]
        public void PrintFigureInfoContravarianceTest()
        {
            IFigurePrintInfo<Rectangle> figure1 = new PrintFigureInfo<BaseFigure>();
            figure1.PrintInfoThroughEvent(new Rectangle(2, 3));
        }
    }
}
