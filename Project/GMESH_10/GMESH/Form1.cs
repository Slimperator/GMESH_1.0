using Geometry;
using Parser;
using Solvers;
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
        private int currentClickedPoint = -1;
        const int rad = 10;

        List<ICurve> curves = new List<ICurve>();
        List<IPoint> points = new List<IPoint>();
        RegMesh2D mesh;

        private Parser.Parser parser = new Parser.Parser();
        private IProcessing preproc;
        private IProcessing postproc;

        public Form1()
        {
            InitializeComponent();
        }

        // Logic Section
        int IsContain(MouseEventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (Math.Pow(points[i].X - e.X, 2) + Math.Pow(points[i].Y - e.Y, 2) <= rad * rad)
                {
                    return i;
                }
            }
            return -1;
        }

        // Event section
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsContain(e) == -1)
            {
                points.Add(new Geometry.Point(e.X, e.Y));
                if (points.Count == 2)
                {
                    curves.Add(new Line(points[1], points[0]));
                    curves.Add(new Line(points[0], points[1]));
                }
                if (points.Count >= 3)
                {
                    curves.RemoveAt(curves.Count - 1);
                    curves.Add(new Line(points[points.Count - 2], points[points.Count - 1]));
                    curves.Add(new Line(points[points.Count - 1], points[0]));
                }
            }
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            currentClickedPoint = IsContain(e);
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            currentClickedPoint = -1;
            Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentClickedPoint == -1)
                return;
            points[currentClickedPoint].X = e.X;
            points[currentClickedPoint].Y = e.Y;
            Refresh();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {/*
            if (currentClickedPoint != -1)
            {
                curves.RemoveAt((currentClickedPoint - 1) % (curves.Count - 1));
                curves.RemoveAt(currentClickedPoint % (curves.Count - 1));
                points.RemoveAt(currentClickedPoint);
                curves.Insert((currentClickedPoint - 1) % (curves.Count - 1), new Line(points[currentClickedPoint - 1], points[currentClickedPoint]));
            }
            Refresh();*/
        }

        private void Build_Click(object sender, EventArgs e)
        {
            Contour contour = new Contour(curves);
            if (contour.Size == 4)
            {
                IMeshGen generator = new QuadSimpleMeshGen(10, 10);
                mesh = generator.Generate(contour);
            }
            Refresh();
        }


        private void Open_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        // Draw Section
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        void Draw(Graphics e)
        {
            drawPoints(e);
            drawCurves(e);
            drawMesh(e);
        }

        void drawCurves(Graphics e)
        {
            if (curves.Count >= 3)
            {
                double h = 0.01;
                double x1, x2, y1, y2;
                foreach (var curve in curves)
                {
                    for (double t = 0; t < 1; t += h)
                    {
                        curve.getPoint(t, out x1, out y1);
                        curve.getPoint(t + h, out x2, out y2);
                        e.DrawLine(new Pen(Color.Black), (int)x1, (int)y1, (int)x2, (int)y2);
                    }
                }
            }
        }

        void drawPoints(Graphics e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (i == currentClickedPoint)
                {
                    e.FillEllipse(new SolidBrush(Color.Magenta), 
                        (int)(points[i].X - 10), (int)(points[i].Y - 10),
                        (int)(2 * rad), (int)(2 * rad));
                }
                else
                {
                    e.DrawEllipse(new Pen(Color.Red),
                        (int)(points[i].X - 10), (int)(points[i].Y - 10),
                        (int)(2 * rad), (int)(2 * rad));
                }
                e.DrawString((i + 1).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black),
                    (int)(points[i].X - 10), (int)(points[i].Y - 10));
            }
        }

        void drawMesh(Graphics e)
        {
            if (mesh != null) 
            {
                for (int i = 0; i < mesh.Y - 1; i++)
                {
          
                    for (int j = 0; j < mesh.X - 1; j++)
                    {
                        e.DrawLine(new Pen(Color.Black), (int)mesh[i, j].X, (int)mesh[i, j].Y, (int)mesh[i, j + 1].X, (int)mesh[i, j + 1].Y);
                        e.DrawLine(new Pen(Color.Black), (int)mesh[i, j].X, (int)mesh[i, j].Y, (int)mesh[i + 1, j].X, (int)mesh[i + 1, j].Y);
                    }               
                }
                mesh = null;
            }      
        }   
    }
}

