using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public interface IMeshGen
    {
        Point[,] Generate(List<ICurve> curves);
    }
}
