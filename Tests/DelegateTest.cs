using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class DelegateTest
    {
        public int Adding(int a, int b)
        {
            return a + b;
        }

        public int ThrowingMethod(int a, int b)
        {
            throw new Exception("Excepttion");
        }

        [TestMethod]
        public void SimpleDelegateTest()
        {
            var type = Type.GetType(ToString());
            Debug.Assert(type != null, nameof(type) + " != null");
            var multiplicationMethod = type.GetMethod(nameof(this.Adding));
            var myDelegate = new DelegateClass(multiplicationMethod);
            Assert.AreEqual(7, myDelegate.Invoke(this, new object[] { 3, 4 }));
        }

        [TestMethod]
        public void IgnoreExceptionTest()
        {
            var type = Type.GetType(ToString());
            Debug.Assert(type != null, nameof(type) + " != null");
            var multiplicationMethod = type.GetMethod(nameof(this.Adding));
            var myDelegate = new DelegateClass(multiplicationMethod);
            var throwingMethod = type.GetMethod(nameof(this.ThrowingMethod));
            myDelegate -= myDelegate;
            myDelegate += new DelegateClass(throwingMethod);
            myDelegate += new DelegateClass(throwingMethod);
            myDelegate += myDelegate;
            var anotherDelegate = new DelegateClass(multiplicationMethod);
            myDelegate += anotherDelegate;
            var result = myDelegate.Invoke(this, new object[] { 5, 8 });
            Assert.AreEqual(13, (int)result);
            Console.WriteLine("Результат после исключений: " + result);
        }
    }
}
