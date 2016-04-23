using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    public class Segment : ISegment
    {
        private IPoint st;
        private IPoint fin;

        public Segment(IPoint st, IPoint fin)
        {
            this.st = st;
            this.fin = fin;
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

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Fin.X - this.St.X, 2) + Math.Pow(this.Fin.Y - this.St.Y, 2));
            }
        }

        public void getPoint(double t, out double x, out double y)
        {
            x = (1 - t) * this.st.X + t * this.fin.X;
            y = (1 - t) * this.st.Y + t * this.fin.Y;
        }

        public void accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
