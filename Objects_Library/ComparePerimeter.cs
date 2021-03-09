using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class ComparePerimeter : IComparer<BaseFigure>
    {
        public int Compare(BaseFigure x, BaseFigure y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("Comparison error! Argument cannot be null.");
            }
            else
            {
                double xPerimeter = x.Perimeter();
                double yPerimeter = y.Perimeter();
                if (xPerimeter < yPerimeter)
                    return -1;
                else
                {
                    if (xPerimeter.Equals(yPerimeter))
                        return 0;
                    else
                        return 1;
                }
            }
        }
    }
}
