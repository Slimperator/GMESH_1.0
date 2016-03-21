using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
    }

    public interface ISegment
    {
        IPoint st { get; set; }
        IPoint fin { get; set; }
    }

    public interface Curve
    {
        void getPoint(double t, out IPoint p);
    }
}
