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
        IPoint St { get; set; }
        IPoint Fin { get; set; }
    }


    public interface ICurve
    {
        void getPoint(double t, out IPoint p);
    }
}
