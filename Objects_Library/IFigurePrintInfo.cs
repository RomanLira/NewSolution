using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public interface IFigurePrintInfo<in T>
    {
        void PrintInfoThroughEvent(T figure);
    }
}
