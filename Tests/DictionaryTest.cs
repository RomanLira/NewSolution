using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class DictionaryTest
    {
        private Stopwatch stopwatch = new Stopwatch();
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

        [TestMethod]
        public void Add100PersonsTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionary(100);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonListGenerator(100);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add10000PersonsTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionary(10000);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonListGenerator(10000);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100000PersonsTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionary(100000);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonListGenerator(100000);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100PersonsWithConstHashCodeTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(100);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonWithConstHashCodeListGenerator(100);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add10000PersonsWithConstHashCodeTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(10000);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonWithConstHashCodeListGenerator(10000);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }

        [TestMethod]
        public void Add100000PersonsWithConstHashCodeTest()
        {
            stopwatch.Restart();
            var dictionary = generator.WorkPlaceDictionaryConstHashCode(100000);
            Console.WriteLine("In Dictionary: " + stopwatch.ElapsedMilliseconds + "ms");
            CollectionAssert.AllItemsAreNotNull(dictionary);
            stopwatch.Restart();
            var persons = PersonWithConstHashCodeListGenerator(100000);
            Console.WriteLine("In List: " + stopwatch.ElapsedMilliseconds + "ms");
            Assert.IsNotNull(persons);
        }
    }
}
