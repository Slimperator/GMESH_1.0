using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle : ICurve
    {
        private IPoint center;
        private double radius;


        public Circle(IPoint center, double radius)
        {
            this.center = center;
            this.radius = radius;

        }
        public void getPoint(double t, out double x, out double y)
        {
            t *= 2 * Math.PI;
            x = this.center.X + this.radius * Math.Cos(t);
            y = this.center.Y + this.radius * Math.Sin(t);
        }

        public void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
