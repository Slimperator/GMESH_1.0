using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Cardioid : ICurve
    {
        private double radius;

        public Cardioid(double radius)
        {
            this.radius = radius;
        }
        public void getPoint(double t, out double x, out double y)
        {
            x = 2*this.radius*Math.Cos(t) - this.radius*Math.Cos(2*t);
            y = 2 * this.radius * Math.Sin(t) - this.radius * Math.Sin(2 * t); ;
        }
    }
}
