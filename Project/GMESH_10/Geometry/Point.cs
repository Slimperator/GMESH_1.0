using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IPoint
    {
        private double x;
        private double y;
        static int rad = 10;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
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
            g.DrawEllipse(new Pen(Color.Red), Convert.ToInt32(this.x - rad), Convert.ToInt32(this.y - rad), Convert.ToInt32(2 * rad), Convert.ToInt32(2 * rad));
        }

        public bool IsContain(double x, double y)
        {
            return (this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= rad * rad;
        }
        public void Fill(Graphics g)//закрасить выбранную точку
        {
            g.FillEllipse(new SolidBrush(Color.Green), Convert.ToInt32(this.x - rad), Convert.ToInt32(this.y - rad), Convert.ToInt32(2 * rad), Convert.ToInt32(2 * rad));
        }
    }
}
