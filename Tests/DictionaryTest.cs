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

        [TestMethod]
        public void ValueAvailableForKeyTest()
        {
            var dictionary = generator.WorkPlaceDictionary(10);
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
    }
}
