using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMESH_prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Point
        {
            public int xCoord;
            public int yCoord;
            public int rad = 10;

            public Point(int xCoord, int yCoord)
            {
                this.xCoord = xCoord;
                this.yCoord = yCoord;
            }

            public void Draw(Graphics g)
            {
                g.DrawEllipse(new Pen(Color.Black), xCoord - rad, yCoord - rad, rad * 2, rad * 2);
            }

            public bool isContain(int xCoord, int yCoord)
            {
                return (this.xCoord - xCoord) * (this.xCoord - xCoord) + (this.yCoord - yCoord) * (this.yCoord - yCoord) <= rad * rad;
            }
        }

        List<Point> points = new List<Point>();

        void DrawPoints()
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].Draw(Graphics.FromHwnd(Handle));
                Graphics.FromHwnd(Handle).DrawString(i.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), points[i].xCoord, points[i].yCoord);
            }
            if (points.Count >= 3)
                for (int i = 1; i <= points.Count; i++)
                {
                    Graphics.FromHwnd(Handle).DrawLine(new Pen(Color.Black), points[i % points.Count].xCoord, points[i % points.Count].yCoord, points[(i - 1) % points.Count].xCoord, points[(i - 1) % points.Count].yCoord);
                }
        }

        int isContain(MouseEventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
                if (points[i].isContain(e.X, e.Y))
                    return i;
            return -1;
        }

        int movedPoint = -1;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (isContain(e) == -1)
            {
                Point point = new Point(e.X, e.Y);
                points.Add(point);
                Refresh();
            }*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawPoints();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            movedPoint = isContain(e);
            if (movedPoint == -1)
            {
                Point point = new Point(e.X, e.Y);
                points.Add(point);
            }
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            movedPoint = -1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (movedPoint == -1) return;
            else
            {
                points[movedPoint].xCoord = e.X;
                points[movedPoint].yCoord = e.Y;
            }
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
