using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class Circle : BaseFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Error! Invalid value. Radius must be > 0.");
            else
                Radius = radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return "Circle [" + Radius + "]";
        }
    }
}
