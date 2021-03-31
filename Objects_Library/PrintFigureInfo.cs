using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class PrintFigureInfo<T> :IFigurePrintInfo<T>
        where T: BaseFigure
    {
        public delegate void Notifier(string message);
        public event Notifier Notify;

        public void PrintInfoThroughEvent(T figure)
        {
            var message = figure.ToString() + " has Area: " + figure.Area()
                + "; has Perimeter: " + figure.Perimeter();
            if (Notify == null)
                Notify += PrintMessage;
            Notify?.Invoke(message);
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
