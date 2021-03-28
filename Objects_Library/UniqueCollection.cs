using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace Objects_Library
{
    public class UniqueCollection<T>
    {
        private Collection<T> _collection;

        public UniqueCollection()
        {
            _collection = new Collection<T>();
        }

        public void Add(T element)
        {
            if (element == null)
                throw new ArgumentNullException("Null cannot added in collection");
            else
            {
                if (_collection.Contains(element))
                    throw new ArgumentException(element + "is already in collection");
                else
                    _collection.Add(element);
            }
        }

        public void Print()
        {
            foreach (T elem in _collection)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine();
        }
    }
}
