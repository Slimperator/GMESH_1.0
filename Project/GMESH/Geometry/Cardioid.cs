using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Cardioid : ICurve
    {
        private IPoint center;
        private double radius;

        public Cardioid(IPoint center, double radius)
        {
            this.center = new Point(center.X, center.Y);
            this.radius = radius;
        }
        public void getPoint(double t, out double x, out double y)
        {
            x = this.center.X + (2 * this.radius*Math.Cos(2 * Math.PI*t) - this.radius*Math.Cos(2 * 2 * Math.PI * t));
            y = this.center.Y + (2 * this.radius * Math.Sin(2 * Math.PI*t) - this.radius * Math.Sin(2 * 2 * Math.PI * t)); 
        }
    }
}
