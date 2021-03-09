using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class ComparableInterfaceTest
    {
        private BaseFigure[] _figuresArray = new BaseFigure[10];
        private enum SortingArguments { Area, Perimeter }

        private void FigureGeneration()
        {
            Random rand = new Random();
            for (int i = 0; i < _figuresArray.Length; i++)
            {
                switch (rand.Next(1, 4))
                {
                    case 1:
                        _figuresArray[i] = new Circle(rand.Next(1, 10));
                        break;
                    case 2:
                        _figuresArray[i] = new Rectangle(rand.Next(1, 10), rand.Next(1, 10));
                        break;
                    case 3:
                        int a = rand.Next(4, 9);
                        int b = rand.Next(4, 9);
                        int c = (a + b) / 2;
                        _figuresArray[i] = new Triangle(a, b, c);
                        break;
                }
            }
        }

        private void SortByPerimeter()
        {
            Array.Sort(_figuresArray, new ComparePerimeter());
        }

        private void SortByArea()
        {
            Array.Sort(_figuresArray, new CompareArea());
        }

        private bool Sort(BaseFigure[] array, SortingArguments arg)
        {
            if (array == null)
                throw new ArgumentException("Array cannot be null.");
            else
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (arg == SortingArguments.Perimeter)
                    {
                        if (array[i - 1].Perimeter() > array[i].Perimeter())
                            return false;
                    }
                    else
                    {
                        if (array[i - 1].Area() > array[i].Area())
                            return false;
                    }
                }
                return true;
            }
        }

        private void Print(SortingArguments arg)
        {
            foreach (var figure in _figuresArray)
            {
                if (arg == SortingArguments.Perimeter)
                    Console.WriteLine(figure + "has Perimeter = " + figure.Perimeter());
                else
                    Console.WriteLine(figure + "has Area = " + figure.Area());
            }
            Console.WriteLine();
        }

        [TestInitialize]
        public void Initialization()
        {
            FigureGeneration();
        }

        [TestMethod]
        public void SortByPerimeterTest()
        {
            SortByPerimeter();
            Print(SortingArguments.Perimeter);
            Assert.IsTrue(Sort(_figuresArray, SortingArguments.Perimeter));
        }

        [TestMethod]
        public void SortByAreaTest()
        {
            SortByArea();
            Print(SortingArguments.Area);
            Assert.IsTrue(Sort(_figuresArray, SortingArguments.Area));
        }
    }
}
