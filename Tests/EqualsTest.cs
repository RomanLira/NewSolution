using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;

namespace Tests
{
    [TestClass]
    public class EqualsTest
    {
        private Person _person1;
        private Person _person2;
        private Person _person3;

        [TestInitialize]
        public void Initialize()
        {
            _person1 = new Person("Petrov Petr Petrovich", "21-12-1995", "Krasnodar", "AA1488228");
            _person2 = new Person("Petrov Petr Petrovich", "21-12-1995", "Krasnodar", "AA148822837");
            _person3 = new Person("Petrov Petr Ivanovich", "21-12-1995", "Sochi", "AA8228841");
        }

        [TestMethod]
        public void EqualPersonTest()
        {
            Assert.IsTrue(_person1.Equals(_person2));
        }

        [TestMethod]
        public void NotEqualPersonTest()
        {
            Assert.IsFalse(_person1.Equals(_person3));
        }

        [TestMethod]
        public void GetHashCodeInEqualPersonTest()
        {
            Assert.IsTrue(_person1.GetHashCode() == _person2.GetHashCode());
        }
    }
}
