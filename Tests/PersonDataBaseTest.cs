using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Objects_Library;
using System.IO;

namespace Tests
{
    [TestClass]
    public class PersonDataBaseTest
    {
        private PersonDataBase dataBase = new PersonDataBase();
        private PersonGenerator generator = new PersonGenerator();

        [TestMethod]
        public void AddDeleteTest()
        {
            var p1 = generator.GeneratePerson();
            var p2 = generator.GeneratePerson();
            dataBase.Add(p1);
            dataBase.Add(p2);
            Assert.IsTrue(2 == dataBase.Count());
            dataBase.Delete(p2);
            Assert.IsTrue(1 == dataBase.Count());
        }

        [TestMethod]
        public void SaveLoadTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var p = generator.GeneratePerson();
                dataBase.Add(p);
            }
            dataBase.Save();
            dataBase.Load(Directory.GetCurrentDirectory() + @"/PersonCatalog.txt");
            Assert.IsTrue(100 == dataBase.Count());
        }

        [TestMethod]
        public void ChangePersonDataTest()
        {
            var p = generator.GeneratePerson();
            dataBase.Add(p);
            dataBase.ChangePersonData(p, PersonDataBase.PersonData.ID, "11111111");
            var pClone = new Person(p.FullName, p.BirthDay, p.BirthPlace, "11111111");
            Assert.IsTrue(dataBase.Search(pClone.GetHashCode()).ID == pClone.ID);
        }
    }
}
