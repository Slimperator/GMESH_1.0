using Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMESH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double x, y;
        double x1, y1, x2, y2;
        double radius = 100;
        double t = 0;
        double h = 0.01;
        IPoint center;
        ICurve curve;
        IPoint P0, P1, P2, P3; // для Безье
        IPoint L1, L2;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DrawAstroid()
        {
            Graphics g = this.CreateGraphics();
            x = 200;
            y = 200;
            center = new Geometry.Point(x, y);
            curve = new Astroid(center, radius);
            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Orange), (int)x1, (int)y1, (int)x2, (int)y2);
            }
        }

        private void DrawCardioid()
        {
            Graphics g = this.CreateGraphics();
            x = 600;
            y = 300;
            center = new Geometry.Point(x, y);
            curve = new Cardioid(center, radius);
            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Purple), (int)x1, (int)y1, (int)x2, (int)y2);
            }
        }
        private void DrawBezier()
        {
            Graphics g = this.CreateGraphics();
           
            P0 = new Geometry.Point(200, 200);
            P1 = new Geometry.Point(300, 100);
            P2 = new Geometry.Point(400, 100);
            P3 = new Geometry.Point(500, 200);
            curve = new Bezier(P0, P1, P2, P3);

            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Green), (int)x1, (int)y1, (int)x2, (int)y2);

            }
        }

        private void DrawLine()
        {
            Graphics g = this.CreateGraphics();
            L1 = new Geometry.Point(50, 50);
            L2 = new Geometry.Point(400, 200);
            curve = new Line(L1, L2);

            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.LightBlue,2), (int)x1, (int)y1, (int)x2, (int)y2);

            }            
        }


        private void DrawCycloid()
        {
            Graphics g = this.CreateGraphics();
            L1 = new Geometry.Point(50, 50);
            L2 = new Geometry.Point(100, 50);
            curve = new Cycloid(L1, L2, true);
            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Red, 1), (int)x1, (int)y1, (int)x2, (int)y2);
            }
        }

        private void DrawCircle()
        {
            Graphics g = this.CreateGraphics();
            x = 150;
            y = 150; 
            center = new   Geometry.Point(x, y);
            curve = new Circle(center,radius);
            for (t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Blue), (int)x1, (int)y1, (int)x2, (int)y2);
            }
        }

        private void Painting(object sender, PaintEventArgs e)
        {
            DrawAstroid();
            DrawCardioid();
            DrawBezier();
            DrawLine();
            DrawCircle();
            DrawCycloid();
        }
    }
}
