using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    public class Segment : ISegment
    {
        IPoint st;
        IPoint fin;

        public Segment(IPoint st, IPoint fin)
        {
            this.st = new Point(st.X, st.Y);
            this.fin = new Point(fin.X, fin.Y);
        }

        public IPoint Fin
        {
            get
            {
                return this.fin;
            }

            set
            {
                this.fin = value;
            }
        }

        public IPoint St
        {
            get
            {
                return this.st;
            }

            set
            {
                this.st = value;
            }
        }

        public void getPoint(double t, out double x, out double y)
        {
            x = (1 - t) * this.st.X + t * this.fin.X;
            y = (1 - t) * this.st.Y + t * this.fin.Y;
        }
    }
}
