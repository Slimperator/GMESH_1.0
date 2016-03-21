using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IPoint
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get
            {
                return this.X;
            }

            set
            {
                this.X = value;
            }
        }

        public double Y
        {
            get
            {
                return this.Y;
            }

            set
            {
                this.Y = value;
            }
        }
    }
}
