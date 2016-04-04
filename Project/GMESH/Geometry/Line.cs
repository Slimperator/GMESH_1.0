using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Line : ICurve
    {
        private IPoint L1;
        private IPoint L2;

        public Line(IPoint L1, IPoint L2)
        {
            this.L1 = new Point(L1.X, L1.Y);
            this.L2 = new Point(L2.X, L2.Y);
            
        }
        public void getPoint(double t, out double x, out double y)
        {
            x = this.L1.X + (1 - t) * L2.X;
            y = this.L1.Y + (1 - t) * L2.Y;

            //x = this.L1.X * (1 - t) + t * L2.X;
            //y = this.L1.Y * (1 - t) + t * L2.Y;
        }
    }
}
