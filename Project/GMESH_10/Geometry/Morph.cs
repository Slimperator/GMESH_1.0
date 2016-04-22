using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class Morph : ICurve
    {
        private ICurve a;
        private ICurve b;
        private double alpha;

        public Morph(ICurve a, ICurve b, double alpha)
        {
            this.a = a;
            this.b = b;
            this.alpha = alpha;
        }

        public void getPoint(double t, out double x, out double y)
        {
            double ax, ay, bx, by;

            a.getPoint(t, out ax, out ay);
            b.getPoint(t, out bx, out by);

            x = this.alpha * ax + (1 - this.alpha) * bx;
            y = this.alpha * ay + (1 - this.alpha) * by;
        }
    }
}
