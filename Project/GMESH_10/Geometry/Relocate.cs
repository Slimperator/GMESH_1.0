using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class Relocate : ICurve
    {
        private Point newA, newB;
        private ICurve curve;

        public Relocate(ICurve curve, Point newA, Point newB)
        {
            this.newA = newA;
            this.newB = newB;
            this.curve = curve;
        }

        public void getPoint(double t, out double x, out double y)
        {
            double ax, ay, bx, by;
            this.curve.getPoint(0, out ax, out ay);
            this.curve.getPoint(1, out bx, out by);
            this.curve.getPoint(t, out x, out y);
            x += (1 - t) * (this.newA.X - ax) + t * (this.newB.X - bx);
            y += (1 - t) * (this.newA.Y - ay) + t * (this.newB.Y - by);
        }
        public void aboutCurve(out string type, out List<IPoint> Points, out List<string> Special)
        {
            throw new NotImplementedException();
        }
    }
}
