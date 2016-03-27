using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMESH_prototype_Kirakosyan
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
             int rad = 10;
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

            public int Rad
            {
                get { return this.rad; }
                set { this.rad = value; }
            }
            public void drawPoint(Graphics g)
            {
                g.DrawEllipse(new Pen(Color.Black), this.x - this.rad, this.y - this.rad, 2*this.rad, 2 * this.rad);
            }

            public bool isContain(int x, int y)
            {
                return ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= rad * rad);
            }

        }

        List<Point> points = new List<Point>();

        int isContain(MouseEventArgs e)
        {
            for (int i = 0; i < points.Count(); i++)
            {
                if (points[i].isContain(e.X, e.Y))
                {
                    return i;
                }

            }
       
                 return -1;
        }
          
        private void createPoint(object sender, MouseEventArgs e)
        {
            if(isContain(e) == -1)
            {
                Point t = new Point(e.X, e.Y);
                points.Add(t);
                Refresh();
            }
            Graphics g = this.CreateGraphics();
            draw(g);

        }
        void draw(Graphics g)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].drawPoint(g);

                g.DrawString((i + 1).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), points[i].X - points[i].Rad, points[i].Y - points[i].Rad);

            }

            if (points.Count >= 3)
            {
                for (int j = 1; j <= points.Count; j++)
                    g.DrawLine(new Pen(Color.Black), points[j % points.Count].X, points[j % points.Count].Y,
                        points[(j - 1) % points.Count].X, points[(j - 1) % points.Count].Y);
            }

        }

        int index = -1;

        private void fixPoint(object sender, MouseEventArgs e)
        {
            index = isContain(e);
           // Refresh();
           
        }

        private void movePoint(object sender, MouseEventArgs e)
        {
            if (index == -1)
            {
                return;
            }
            else
            {

                points[index].X = e.X;
                points[index].Y = e.Y;
            }
            Refresh();

        }

        private void freedomPoint(object sender, MouseEventArgs e)
        {
            index = -1;
        }

        private void delitePoint(object sender, MouseEventArgs e)
        {
            if (index == -1)

                return;
            else
            {
                int count = points.Count();

            points.RemoveAt(index);
              
            }
           

        }
    }
}
