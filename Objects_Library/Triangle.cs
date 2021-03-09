using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class Triangle : BaseFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Error! Invalid value. Sides must be > 0.");
            else
            {
                if (a + b <= c || a + c <= b || b + c <= a)
                    throw new ArgumentException("Error! Triangle doesn't exist.");
                else
                {
                    A = a;
                    B = b;
                    C = c;
                }
            }
        }

        public override double Perimeter()
        {
            return A + B + C;
        }

        public override double Area()
        {
            double HalfPerimeter = Perimeter() / 2;
            return Math.Sqrt(HalfPerimeter * (HalfPerimeter - A) * (HalfPerimeter - B) * (HalfPerimeter - C));
        }

        public override string ToString()
        {
            return "Triangle [" + A + " " + B + " " + C + "]";
        }
    }
}
