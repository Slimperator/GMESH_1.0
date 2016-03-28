using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    public class Segment : ISegment
    {
        public Segment(IPoint st, IPoint fin)
        {
            this.St = st;
            this.Fin = fin;
        }

        public IPoint Fin
        {
            get
            {
                return this.Fin;
            }

            set
            {
                this.Fin = value;
            }
        }

        public IPoint St
        {
            get
            {
                return this.St;
            }

            set
            {
                this.St = value;
            }
        }

        public void getPoint(double t, out double x, out double y)
        {
            x = (1 - t) * this.St.X + t * this.Fin.X;
            y = (1 - t) * this.St.Y + t * this.Fin.Y;
        }
    }
}
