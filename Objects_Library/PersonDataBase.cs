using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class PersonDataBase
    {
        private Dictionary<int, Person> _personDataBase;

        public PersonDataBase()
        {
            _personDataBase = new Dictionary<int, Person>();
        }

        public enum PersonData
        {
            FullName, BirthDay, BirthPlace, ID
        }

        public int Count()
        {
            return _personDataBase.Count;
        }

        public bool IsPersonUnique(Person p)
        {
            if (_personDataBase.ContainsKey(p.GetHashCode()))
                return false;
            return true;
        }

        public void Add(Person p)
        {
            if (IsPersonUnique(p))
            {
                _personDataBase.Add(p.GetHashCode(), p);
            }
            else
                throw new ArgumentException("Person is not unique!");
        }

        public void Delete (Person p)
        {
            if (p == null)
                throw new ArgumentNullException("Argument cannot be null");
            if (_personDataBase.ContainsKey(p.GetHashCode()))
                _personDataBase.Remove(p.GetHashCode());
        }

        public Person Search(int k)
        {
            if (_personDataBase.ContainsKey(k))
                return _personDataBase[k];
            else
                throw new ArgumentException("Person with this key are not found");
        }

        public void ChangePersonData(Person p, PersonData changedData, string value)
        {
            if (!_personDataBase.ContainsKey(p.GetHashCode()))
                return;
            Person personWithNewData;
            switch(changedData)
            {
                case PersonData.FullName:
                    personWithNewData = new Person(value, p.BirthDay, p.BirthPlace, p.ID);
                    Add(personWithNewData); break;
                case PersonData.BirthDay:
                    personWithNewData = new Person(p.FullName, value, p.BirthPlace, p.ID);
                    Add(personWithNewData); break;
                case PersonData.BirthPlace:
                    personWithNewData = new Person(p.FullName, p.BirthDay, value, p.ID);
                    Add(personWithNewData); break;
                case PersonData.ID:
                    personWithNewData = new Person(p.FullName, p.BirthDay, p.BirthPlace, value);
                    Add(personWithNewData); break;
            }
            _personDataBase.Remove(p.GetHashCode());
        }

        public void Save()
        {
            var dataDirectory = Directory.GetCurrentDirectory();
            using (var fileWriter = new StreamWriter(dataDirectory + @"/PersonCatalog.txt"))
                foreach (var p in _personDataBase)
                    fileWriter.WriteLine(p.Key + " " + p.Value);
            Console.WriteLine("Directory: " + dataDirectory);
        }

        public void Load(string path)
        {
            using (var fileReader = new StreamReader(path))
            {
                var newDataBase = new Dictionary<int, Person>();
                string _string = fileReader.ReadLine();
                while (_string != null)
                {
                    var data = _string.Split(' ');
                    var p = new Person(
                        data[1] + " " + data[2] + " " + data[3],
                        data[4],
                        data[5],
                        data[6]
                        );
                    newDataBase.Add(int.Parse(data[0]), p);
                    _string = fileReader.ReadLine();
                }
                _personDataBase = newDataBase;
            }
        }

        public override string ToString()
        {
            foreach (var p in _personDataBase)
            {
                Console.WriteLine("{0} {1}", p.Key, p.Value);
            }
            return string.Format("");
        }
    }
}
