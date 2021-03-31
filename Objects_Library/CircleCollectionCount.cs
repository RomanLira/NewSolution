using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class CircleCollectionCount<T> : IFigureCollectionCount<T>
        where T: BaseFigure
    {
        private IEnumerable<T> _circles;
        public delegate void Notifier(string message);
        public event Notifier Notify;

        public CircleCollectionCount(IEnumerable<T> circles)
        {
            if (circles == null)
                throw new ArgumentNullException("Collection is empty");
            _circles = circles;
            Notify += PrintMessage;
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int CollectionCount()
        {
            Notify?.Invoke("Collection's count is calculated");
            return _circles.Count();
        }
    }
}
