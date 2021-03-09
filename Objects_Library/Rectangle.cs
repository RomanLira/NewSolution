using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class Rectangle : BaseFigure
    {
        public double A { get; set; }
        public double B { get; set; }

        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new AccessViolationException("Error! Invalid value. Sides must be > 0.");
            else
            {
                A = a;
                B = b;
            }
        }

        public override double Perimeter()
        {
            return 2 * (A + B);
        }

        public override double Area()
        {
            return A * B;
        }

        public override string ToString()
        {
            return "Rectangle [" + A + " " + B + "]";
        }
    }
}
