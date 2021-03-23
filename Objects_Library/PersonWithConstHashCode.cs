using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class PersonWithConstHashCode : Person
    {
        public PersonWithConstHashCode(string fullName, string birthDay, string birthPlace, string iD)
            : base(fullName, birthDay, birthPlace, iD)
        {

        }

        public override int GetHashCode()
        {
            return 228;
        }
    }
}
