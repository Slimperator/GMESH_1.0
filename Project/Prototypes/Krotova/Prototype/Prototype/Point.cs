using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Point
    {
        int x, y;
        static int rad = 10;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public int R
        {
            get { return rad; }
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red), this.x - rad, this.y - rad, 2 * rad, 2 * rad);
        }

        public bool IsContain(int x, int y)
        {
            return (this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= rad * rad;
        }
        public void Fill(Graphics g)//закрасить выбранную точку
        {
            g.FillEllipse(new SolidBrush(Color.Green), this.x - rad, this.y - rad, 2 * rad, 2 * rad);
        }
    }
}
