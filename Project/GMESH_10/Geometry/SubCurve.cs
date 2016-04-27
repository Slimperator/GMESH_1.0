using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class SubCurve: ICurve
    {
        private ICurve mainCurve;
        public Point begin {get; private set; }
        public Point end { get; private set; }
        private double paramBegin, paramEnd, max, min;

        public SubCurve(ICurve mainCurve, double paramTBegin, double paramTEnd)
        {
            double x, y;
            this.mainCurve = mainCurve;
            this.paramBegin = paramTBegin;
            this.paramEnd = paramTEnd;
            this.mainCurve.getPoint(paramBegin,out x,out y);
            begin = new Point(x,y);
            this.mainCurve.getPoint(paramEnd, out x, out y);
            end = new Point(x, y);
            if (paramBegin > paramEnd) { max = paramBegin; min = paramEnd; }
            if (paramBegin < paramEnd) { max = paramEnd; min = paramBegin; }
        }
        public void getPoint(double t, out double x, out double y)
        {
            this.mainCurve.getPoint(t * (max - min) + min, out x, out y);
        }

        public void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
