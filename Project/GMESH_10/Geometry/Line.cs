using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Line : ICurve
    {
        private IPoint l1;
        private IPoint l2;

        public Line(IPoint l1, IPoint l2)
        {
            this.l1 = l1;
            this.l2 = l2;

        }
        public void getPoint(double t, out double x, out double y)
        {
            x = (1 - t)*this.l1.X + t * l2.X;
            y = (1 - t)*this.l1.Y + t * l2.Y;       
        }

        public void accept(IVisitor visitor)
        {
            visitor.visitLine(this);
        }
    }
}
