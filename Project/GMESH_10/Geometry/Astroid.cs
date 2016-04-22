using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Astroid : ICurve
    {

        private IPoint center;
        private double radius;

        public Astroid(IPoint center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }
        public void getPoint(double t, out double x, out double y)
        {
            x = this.center.X + this.radius * Math.Pow(Math.Sin(2 * Math.PI * t), 3);
            y = this.center.Y + this.radius * Math.Pow(Math.Cos(2 * Math.PI * t), 3);
        }
        public void aboutCurve(out string type, out List<IPoint> Points, out List<string> Special)
        {
            type = "astroid";
            Points = new List<IPoint>() { center };
            Special = new List<string>() { Convert.ToString(radius) };
        }
    }
}
