using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class CompareArea : IComparer<BaseFigure>
    {
        public int Compare(BaseFigure x, BaseFigure y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("Comparison error! Argument cannot be null.");
            }
            else
            {
                double xArea = x.Area();
                double yArea = y.Area();
                if (xArea < yArea)
                    return -1;
                else
                {
                    if (xArea.Equals(yArea))
                        return 0;
                    else
                        return 1;
                }
            }
        }
    }
}
