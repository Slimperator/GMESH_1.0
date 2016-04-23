using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geometry
{
    public class Bezier : ICurve
    {
        public IPoint P0 { get; private set; }
        public IPoint P1 { get; private set; }
        public IPoint P2 { get; private set; }
        public IPoint P3 { get; private set; }

        public Bezier(IPoint P0, IPoint P1, IPoint P2, IPoint P3)
        {
            this.P0 = P0;
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }

        public void getPoint(double t, out double x, out double y)
        {

            x = this.P0.X * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.X * (1 - t) * (1 - t) + 3 * t * t * P2.X * (1 - t) + t * t * t * P3.X;
            y = this.P0.Y * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.Y * (1 - t) * (1 - t) + 3 * t * t * P2.Y * (1 - t) + t * t * t * P3.Y;
        }

        public void accept(IVisitor visitor)
        {
            visitor.visitBezier(this);
        }
    }
}

