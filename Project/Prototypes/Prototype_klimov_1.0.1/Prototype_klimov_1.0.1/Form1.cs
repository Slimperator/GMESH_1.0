using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_klimov_1._0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Point
        {
            int x, y;
            public static int rad = 10;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {
                get { return this.x; }
                set { this.X = value; }
            }
            public int Y
            {
                get { return this.y; }
                set { this.Y = value; }
            }
            public int R
            {
                get { return rad; }
            }
            public void Draw(Graphics g)
            {
                g.DrawEllipse(new Pen(Color.Blue), this.x - rad, this.y - rad, 2 * rad, 2 * rad);
            }
            public bool isContain(int X, int Y)
            {
                return ((this.X - X) * (this.X - X) + (this.Y - Y) * (this.Y - Y) <= rad * rad);
            }
        }

        List<Point> points = new List<Point>(); // список хранения точек

        int isContain(MouseEventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].isContain(e.X, e.Y))
                    return i;
            }
            return -1;
        }

        void Draw(Graphics g)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].Draw(Graphics.FromHwnd(Handle));
            }
            if (points.Count >= 3)
            {
                for (int i = 1; i <= points.Count; i++)
                {
                    g.DrawLine(new Pen(Color.Black), points[i % points.Count].X, points[i % points.Count].Y, points[(i - 1) % points.Count].X, points[(i - 1) % points.Count].Y);
                }
            }
        }

        private void PaintPict(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Draw(g);
        }
        // отрисовываем точку по щелчку
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isContain(e) == -1)
            {
                Point p = new Point(e.X, e.Y);
                points.Add(p);
                Refresh();
            }
        }
        // вводим index
        int index = -1;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            index = isContain(e);
            if (index == -1)
            {
                Point point = new Point(e.X, e.Y);
                points.Add(point);
            }
            Refresh();
        }

        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (index == -1) return;

        //    else
        //    {

        //        points[index].X = e.X;
        //        points[index].Y = e.Y;
        //    }
        //}

        //private void Form1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    index = isContain(e);
        //    if (index == -1)
        //    {
        //        Point point = new Point(e.X, e.Y);
        //        points.Add(point);
        //    }
        //    Refresh();
        //}
    }
}
