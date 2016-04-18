using Geometry;
using Parser;
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
        private bool isClicked = false;
        private bool isBuildClicked = false;
        private int currentClickedPoint = -1;
        List<ICurve> curves = new List<ICurve>();
        List<Geometry.Point> pp = new List<Geometry.Point>();
        private Parser.Parser parser = new Parser.Parser();
        private IProcessing preproc;
        private IProcessing postproc;

        public Form1()
        {
            InitializeComponent();
            ProcessingInit();
            FigureInit();
            MouseDown += Form1_MouseDown;
            MouseDoubleClick += Form1_MouseDoubleClick;
        }

        void FigureInit()
        {
            curves.Add(new Bezier(new Geometry.Point(100, 100), new Geometry.Point(150, 50), new Geometry.Point(200, 50), new Geometry.Point(250, 100)));
            curves.Add(new Bezier(new Geometry.Point(250, 100), new Geometry.Point(260, 150), new Geometry.Point(260, 150), new Geometry.Point(250, 180)));
            curves.Add(new Line(new Geometry.Point(250, 180), new Geometry.Point(150, 200)));
            curves.Add(new Bezier(new Geometry.Point(150, 200), new Geometry.Point(170, 150), new Geometry.Point(170, 150), new Geometry.Point(100, 100)));

            for (double alpha = 0.1; alpha < 1; alpha += 0.1)
            {
                Geometry.Point a, b;
                double x, y;
                curves[1].getPoint(1-alpha, out x, out y);
                a = new Geometry.Point(x, y);
                curves[3].getPoint(alpha, out x, out y);
                b = new Geometry.Point(x, y);
                curves.Add(new Relocate(new Morph(curves[0], curves[2], alpha), a, b));

            }
        }


        void ProcessingInit()
        {
            postproc = parser.PostProcessing;
            preproc = parser.PreProcessing;
        }

        void Draw(Graphics g)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (i == currentClickedPoint)
                {
                    pp[i].Fill(g);
                }
                else
                {
                    pp[i].Draw(g);
                }

                g.DrawString((i + 1).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), Convert.ToInt32((pp[i].X - pp[i].R)), Convert.ToInt32((pp[i].Y - pp[i].R)));
            }
            if (pp.Count >= 3)
            {
                for (int i = 1; i <= pp.Count; i++)
                {
                    g.DrawLine(new Pen(Color.Black), Convert.ToInt32(pp[i % pp.Count].X), Convert.ToInt32(pp[i % pp.Count].Y), Convert.ToInt32(pp[(i - 1) % pp.Count].X), Convert.ToInt32(pp[(i - 1) % pp.Count].Y));
                }
            }

        }

        int IsContain(MouseEventArgs e)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].IsContain(e.X, e.Y) == true)
                {
                    return i;
                }
            }
            return -1;

        }
        private void createPoint(object sender, MouseEventArgs e)
        {
            if (IsContain(e) == -1)
            {
                Geometry.Point p = new Geometry.Point(e.X, e.Y);

                pp.Add(p);
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            if (isBuildClicked)
            {
                drawSpecialFigure(g);
            }
            else
            {
                Draw(g);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            currentClickedPoint = IsContain(e);
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                int pointNum = IsContain(e);

                if (pointNum == -1) return;
                else
                {
                    pp[pointNum].X = e.X;
                    pp[pointNum].Y = e.Y;
                }
                Refresh();
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)//Удалить точку
        {

            int pointNum = IsContain(e);

            if (pointNum == -1) return;
            else
            {
                pp.RemoveAt(pointNum);
            }
            Refresh();

        }

        private void Build_Click(object sender, EventArgs e)
        {
            isBuildClicked = true;
            pp.Clear();
            Refresh();
        }

        
    //=======================================================================
        void drawSpecialFigure(Graphics g)
        {
            foreach (var c in curves)
            {
                drawCurve(c, g);
            }
        }

        void drawCurve(ICurve curve, Graphics g)
        {
            double h = 0.01;
            double x1, x2, y1, y2;
            for (double t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                g.DrawLine(new Pen(Color.Green), (int)x1, (int)y1, (int)x2, (int)y2);

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileSelected = openFileDialog1.FileName;
                //parser.load(fileSelected);
                //preproc.convert(ref curves, ref pp, ref parser.Gmesh.Poligons[0].Curves, ref parser.Gmesh.Poligons[0].Points);
            }  
        }

        private void Save_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileSelected = openFileDialog1.FileName;
                //parser.load(fileSelected);
                //preproc.convert(ref curves, ref pp, ref parser.Gmesh.Poligons[0].Curves, ref parser.Gmesh.Poligons[0].Points);
            }  
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegMesh2D n = new RegMesh2D(10, 10, new Line(pp[0], pp[1]), new Line(pp[1], pp[2]), new Line(pp[2], pp[3]), new Line(pp[3], pp[0]));
            curves = n.GetCurves();
        }
        // 1. тыкаешь точки
        // 2. Gener
        // 3. Build 
        


       
        

        //private void Painting(object sender, PaintEventArgs e)
        //{
        //    draw(e.Graphics);
        //}

    }
}

/*
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
                g.DrawLine(new Pen(Color.LightBlue, 2), (int)x1, (int)y1, (int)x2, (int)y2);

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
            center = new Geometry.Point(x, y);
            curve = new Circle(center, radius);
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
 */