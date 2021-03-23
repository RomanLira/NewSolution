using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class DictionaryTest
    {
        private PersonGenerator generator = new PersonGenerator();

        public IList<Person> PersonListGenerator(int length)
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < length; i++)
            {
                var p = generator.GeneratePerson();
                while (persons.Contains(p))
                    p = generator.GeneratePerson();
                persons.Add(p);
            }
            return persons;
        }

        public IList<PersonWithConstHashCode> PersonWithConstHashCodeListGenerator(int length)
        {
            List<PersonWithConstHashCode> persons = new List<PersonWithConstHashCode>();
            for (int i = 0; i < length; i++)
            {
                var p = generator.GeneratePersonWithConstHashCode();
                while (persons.Contains(p))
                    p = generator.GeneratePersonWithConstHashCode();
                persons.Add(p);
            }
            return persons;
        }

        [TestMethod]
        public void ValueAvailableForKeyTest()
        {
            var dictionary = generator.WorkPlaceDictionary(10000);
            var person = generator.GeneratePerson();
            Console.WriteLine("Person for search: {0}", person.ToString());
            string value = "";
            if (dictionary.TryGetValue(person, out value))
            {
                Console.WriteLine("Person works in " + value);
                Assert.IsTrue(dictionary.ContainsValue(value));
            }
            else
            {
                Console.WriteLine("Person not found");
                Assert.IsFalse(dictionary.ContainsValue(value));
            }
        }

        #region(DictionaryTests)
        [TestMethod]
        public void Add100PersonsInDictionaryTest()
        {
            var dictionary = generator.WorkPlaceDictionary(100);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }

        [TestMethod]
        public void Add10000PersonsInDictionaryTest()
        {
            var dictionary = generator.WorkPlaceDictionary(10000);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }

        [TestMethod]
        public void Add100000PersonsInDictionaryTest()
        {
            var dictionary = generator.WorkPlaceDictionary(100000);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }

        [TestMethod]
        public void Add100PersonsInDictionaryConstHashCodeTest()
        {
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(100);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }

        [TestMethod]
        public void Add10000PersonsInDictionaryConstHashCodeTest()
        {
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(10000);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }

        [TestMethod]
        public void Add100000PersonsInDictionaryConstHashCodeTest()
        {
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(100000);
            CollectionAssert.AllItemsAreNotNull(dictionary);
        }
        #endregion

        #region(ListTests)
        [TestMethod]
        public void Add100PersonsInListTest()
        {
            var persons = PersonListGenerator(100);
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add10000PersonsInListTest()
        {
            var persons = PersonListGenerator(10000);
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100000PersonsInListTest()
        {
            var persons = PersonListGenerator(100000);
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100PersonsWithConstHashCodeInListTest()
        {
            var persons = PersonWithConstHashCodeListGenerator(100);
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add10000PersonsWithConstHashCodeInListTest()
        {
            var persons = PersonWithConstHashCodeListGenerator(10000);
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100000PersonsWithConstHashCodeInListTest()
        {
            var persons = PersonWithConstHashCodeListGenerator(100000);
            Assert.IsNotNull(persons);
        }
        #endregion
    }
}
