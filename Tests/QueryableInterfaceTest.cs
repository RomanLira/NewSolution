using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class QueryableInterfaceTest
    {
        private Random rand = new Random();
        private Storage[] _products = new Storage[100];

        private void GenerateProducts()
        {
            for (int i = 0; i < 100; i++)
            {
                _products[i] = new Storage(GenerateString(rand, 7), rand.Next(0, 100));
            }
        }

        private static char GenerateChar(Random rand)
        {
            return (char)(rand.Next('a', 'z' + 1));
        }

        private static string GenerateString(Random rand, int n)
        {
            char[] names = new char[n];
            for (int i = 0; i < n; i++)
            {
                names[i] = GenerateChar(rand);
            }
            return new string(names);
        }

        [TestInitialize]
        public void Initialization()
        {
            GenerateProducts();
        }

        [TestMethod]
        public void AnyAllWhereTest()
        {
            var Availability1 = _products.All(product => product.Number > 0);
            var Availability2 = _products.Any(product => product.Number == 0);
            if (Availability1)
            {
                Console.WriteLine("All products are in Storage");
            }
            if (Availability2)
            {
                Console.WriteLine("Missing in Storage: ");

                var MissingProducts = from product in _products
                                      where product.Number == 0
                                      select product;

                foreach (var product in MissingProducts)
                {
                    Console.WriteLine(product.ToString());
                }
            }
            Assert.IsTrue(Availability1 || Availability2);
        }

        [TestMethod]
        public void OrderByAndGroupByTest()
        {
            Console.WriteLine("Sort by quantity: ");
            // Act
            var SortProducts = from product in _products
                               orderby product.Number
                               group product by product.Number;
            foreach (IGrouping<int, Storage> product in SortProducts)
            {
                Console.Write(product.Key + ": ");
                foreach (var p in product)
                    Console.Write("{0} ", p.Text);
                Console.WriteLine();
            }
            // Assert
            Assert.AreEqual(SortProducts, SortProducts);
        }

        [TestMethod]
        public void SumMinMaxTest()
        {
            // Act
            var SumProducts = _products.Sum(product => product.Number);
            Console.WriteLine("\nSum of all products in Storage: {0}", SumProducts);
            // Assert
            Assert.IsTrue(SumProducts != 0);

            var MinProducts = _products.Min(product => product.Number);
            Console.WriteLine("\nMinimum number of product: {0}", MinProducts);
            Assert.IsNotNull(MinProducts);

            var MaxProducts = _products.Max(product => product.Number);
            Console.WriteLine("\nMaximum number of product: {0}", MaxProducts);
            Assert.IsNotNull(MaxProducts);
        }
    }
}
