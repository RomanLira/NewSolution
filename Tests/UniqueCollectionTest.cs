using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class UniqueCollectionTest
    {
        private PersonGenerator persongenerator = new PersonGenerator(); 

        private bool AllItemsAreUnique<T>(UniqueCollection<T> _collection)
        {
            List<T> list = new List<T>();
            foreach (var elem in list)
            {
                list.Add(elem);
                if (list.Contains(elem))
                {
                    Console.WriteLine("Collection is not unique");
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void GenerateCollectionTest()
        {
            UniqueCollection<Person> _collection = new UniqueCollection<Person>();
            for (int i = 0; i < 100; i++)
            {
                _collection.Add(persongenerator.GeneratePerson());
            }
            _collection.Print();
            Assert.IsTrue(AllItemsAreUnique<Person>(_collection));
        }
    }
}
