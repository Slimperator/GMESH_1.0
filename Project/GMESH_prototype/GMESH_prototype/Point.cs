using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMESH_prototype
{
    class Point
    {
        private int xCoord;
        private int yCoord;
        private static int radius = 10;

        public Point(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        public int X
        {
            get { return this.xCoord; }
        }

        public int Y
        {
            get { return this.yCoord; }
        }

        public int R
        {
            get { return radius; }
        }
        public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black), this.xCoord - 10, this.yCoord - 10, 2 * radius, 2 * radius);
        }
    }
}
