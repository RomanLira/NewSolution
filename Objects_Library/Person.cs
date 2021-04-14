using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class Person
    {
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public string ID { get; set; }

        public Person (string fullname, string birthday, string birthplace, string id)
        {
            if (fullname == null || birthday == null || birthplace == null || id == null)
                throw new ArgumentNullException("Error! One of arguments is null.");
            else
            {
                FullName = fullname;
                BirthDay = birthday;
                BirthPlace = birthplace;
                ID = id;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Cannot compare with null.");
            if (obj is Person)
            {
                Person p = (Person)obj;
                return p.FullName == FullName &&
                    p.BirthDay == BirthDay &&
                    p.BirthPlace == BirthPlace &&
                    p.ID == ID;
            }
            else
                throw new ArgumentException("Object is not 'Person'.");
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode() + BirthDay.GetHashCode() + BirthPlace.GetHashCode() + ID.GetHashCode();
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException("Cannot compare with null.");
            else
                return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return string.Format(FullName + " " + BirthDay + " " + BirthPlace + " " + ID);
        }
    }
}
