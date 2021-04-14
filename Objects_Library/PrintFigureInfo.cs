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

        public PrintFigureInfo()
        {
            Notify += PrintMessage;
        }

        public void PrintInfoThroughEvent(T figure)
        {
            if (figure == null)
                throw new ArgumentNullException("Figure cannot be null");
            var message = figure.ToString() + " has Area: " + figure.GetArea()
                + "; has Perimeter: " + figure.GetPerimeter();
            Notify?.Invoke(message);
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
