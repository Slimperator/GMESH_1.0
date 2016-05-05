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
    public partial class Form1 : Form, IVisitor
    {
        private int currentClickedPoint = -1;
        private int choosencurve = -1;
        private IPoint[] somePoints;
        private IContourDecompositor decomPentagon = new PentagonTriangleDecompose();
        const int rad = 10;

        List<ICurve> curves = new List<ICurve>();
        List<IPoint> points = new List<IPoint>();
        List<RegMesh2D> meshs;
        ArithmMeanGrade quality = new ArithmMeanGrade();

        private Parser.Parser parser = new Parser.Parser();

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
            if (e.Button == MouseButtons.Left)
            {
                if (IsContain(e) == -1)
                {
                    points.Add(new Geometry.Point(e.X, e.Y));
                    if (points.Count == 2)
                    {
                        curves.Add(new Line(points[0], points[1]));
                        curves.Add(new Line(points[1], points[0]));
                    }
                    if (points.Count >= 3)
                    {
                        curves.RemoveAt(curves.Count - 1);
                        curves.Add(new Line(points[points.Count - 2], points[points.Count - 1]));
                        curves.Add(new Line(points[points.Count - 1], points[0]));
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                ICurve choose = curveAreChoosen(e);
                if (choose != null)
                {
                    choosencurve = curves.IndexOf(choose);
                    CurveMenuStrip.Show(e.X, e.Y);
                }
            }
            Refresh();
        }

        private ICurve curveAreChoosen(MouseEventArgs e)
        {
            double x1, y1, x2, y2, R, D;
            double W = 5;                //толщина линии, куда засчитывается попадание
            foreach (ICurve curve in curves)
            {
                if (curve is Line)
                {
                    curve.getPoint(0, out x1, out y1);
                    curve.getPoint(1, out x2, out y2);

                    R = ((e.X - x1) * (x2 - x1) + (e.Y - y1) * (y2 - y1)) / (Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                    if (R >= 0 && R <= 1)
                    {
                        D = ((y1 - e.Y) * (x2 - x1) - (x1 - e.X) * (y2 - y1)) / (Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
                        if (D <= W && D >= -W)
                        {
                            return curve;
                        }
                    }
                }
                if (curve is Bezier)
                {
                    for (double i = 0.05; i < 1; i += 0.05)
                    {
                        curve.getPoint(i - 0.05, out x1, out y1);
                        curve.getPoint(i, out x2, out y2);

                        R = ((e.X - x1) * (x2 - x1) + (e.Y - y1) * (y2 - y1)) / (Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                        if (R >= 0 && R <= 1)
                        {
                            D = ((y1 - e.Y) * (x2 - x1) - (x1 - e.X) * (y2 - y1)) / (Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
                            if (D <= W && D >= -W)
                            {
                                return curve;
                            }
                        }
                    }
                }
            }
            return null;
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
        {
            // Грязный алгоритм. Надо додумать
            currentClickedPoint = IsContain(e);
            if (currentClickedPoint != -1)
            {
                curves.RemoveAt((currentClickedPoint) % curves.Count);
                if (currentClickedPoint == 0)
                    curves.RemoveAt(curves.Count - 1);
                else
                    curves.RemoveAt((currentClickedPoint - 1) % curves.Count);//?
                points.RemoveAt(currentClickedPoint);
                if (currentClickedPoint - 1 != curves.Count & !(currentClickedPoint == 0))
                    curves.Insert((currentClickedPoint - 1) % (curves.Count), new Line(points[currentClickedPoint - 1], points[currentClickedPoint % points.Count]));
                else
                    curves.Add(new Line(points[(currentClickedPoint - 1 + points.Count) % points.Count], points[currentClickedPoint % points.Count]));
            }
            Refresh();
        }

        private void Build_Click(object sender, EventArgs e)
        {
            Contour contour = new Contour(curves);
            if (contour.Size == 5)
            {
                IContourDecompositor decom = new PentagonTriangleDecompose();
                IContour[] contourTEST;
                meshs = new List<RegMesh2D>();
                IMeshGen generator;// = new TriaMeshGen(10, 10);
                contourTEST = decom.decomposed(contour);              //тестовый код для пятиугольника
                foreach (var x in contourTEST)
                {
                    if (x.Size == 4)
                    {
                        generator = new QuadSimpleMeshGen(10, 10);
                        meshs.AddRange(generator.Generate(x));
                    }
                    if (x.Size == 3)
                    {
                        generator = new TriaMeshGen(10, 10);
                        meshs.AddRange(generator.Generate(x));
                    }
                }
            }
            if (contour.Size == 4)
            {
                //IMeshGen generator = new QuadSimpleMeshGen(10, 10);
                IMeshGen generator = new QuadCleverMeshGen(10, 10);
                //IMeshGen generator = new TriaMeshGen(10, 10);
                meshs = new List<RegMesh2D>();
                meshs.Add(generator.Generate(contour)[0]);
            }
            if (contour.Size == 3)
            {
                meshs = new List<RegMesh2D>();
                IMeshGen generator = new TriaMeshGen(10, 10);
                meshs = generator.Generate(contour);
            }
            double qualitySum = 0;
            for (int i = 0; i < meshs.Count(); i++)
                qualitySum += quality.Calculate(meshs[i]);
            Quality.Text = Convert.ToString(qualitySum / meshs.Count());
            Refresh();
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
                parser.load(fileSelected);
                parser.PreProcessing.convert(ref curves, ref points, ref parser.Gmesh.Poligons[0].Curves, ref parser.Gmesh.Poligons[0].Points);
                Refresh();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileSelected = saveFileDialog1.FileName;
                parser.PostProcessing.convert(ref curves, ref points, ref parser.Gmesh.Poligons[0].Curves, ref parser.Gmesh.Poligons[0].Points);
                parser.save(fileSelected);
                Refresh();
            }
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
                    Pen pen;
                    if (choosencurve == curves.IndexOf(curve)) { pen = new Pen(Color.Red, 4); }
                    else { pen = new Pen(Color.Black); }
                    for (double t = 0; t < 1; t += h)
                    {
                        curve.getPoint(t, out x1, out y1);
                        curve.getPoint(t + h, out x2, out y2);
                        e.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
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
            if (meshs != null)
            {
                foreach (var mesh in meshs)
                {
                    ArithmMeanGrade crit = new ArithmMeanGrade();
                    Gradient st = new Gradient();

                    for (int i = 0; i < mesh.Y - 1; i++)
                    {
                        for (int j = 0; j < mesh.X - 1; j++)
                        {
                            // st.GetCellColor(crit.Calculate(mesh));
                            System.Drawing.Point[] littlemesh = new System.Drawing.Point[4];
                            littlemesh[0] = new System.Drawing.Point((int)(mesh[i, j].X), (int)(mesh[i, j].Y));
                            littlemesh[1] = new System.Drawing.Point((int)(mesh[i + 1, j].X), (int)(mesh[i + 1, j].Y));
                            littlemesh[2] = new System.Drawing.Point((int)(mesh[i + 1, j + 1].X), (int)(mesh[i + 1, j + 1].Y));
                            littlemesh[3] = new System.Drawing.Point((int)(mesh[i, j + 1].X), (int)(mesh[i, j + 1].Y));


                            Geometry.Point[,] littlemesh2 = new Geometry.Point[2, 2];
                            littlemesh2[0, 0] = new Geometry.Point((int)(mesh[i, j].X), (int)(mesh[i, j].Y));
                            littlemesh2[0, 1] = new Geometry.Point((int)(mesh[i + 1, j].X), (int)(mesh[i + 1, j].Y));
                            littlemesh2[1, 0] = new Geometry.Point((int)(mesh[i, j + 1].X), (int)(mesh[i, j + 1].Y));
                            littlemesh2[1, 1] = new Geometry.Point((int)(mesh[i + 1, j + 1].X), (int)(mesh[i + 1, j + 1].Y));



                            int cols = 2;
                            int rows = 2;
                            RegMesh2D mesh2 = new RegMesh2D(littlemesh2, cols, rows);
                            Brush br = new SolidBrush(st.GetCellColor(crit.Calculate(mesh2)));

                            e.FillPolygon(br, littlemesh);
                        }
                    }
                    for (int i = 0; i < mesh.Y - 1; i++)
                    {

                        for (int j = 0; j < mesh.X - 1; j++)
                        {
                            e.DrawLine(new Pen(Color.Black), 
                                (int)mesh[i, j].X, (int)mesh[i, j].Y, 
                                (int)mesh[i, j + 1].X, (int)mesh[i, j + 1].Y);
                            e.DrawLine(new Pen(Color.Black), 
                                (int)mesh[i, j].X, (int)mesh[i, j].Y, 
                                (int)mesh[i + 1, j].X, (int)mesh[i + 1, j].Y);
                        }
                    }
                    e.DrawLine(new Pen(Color.Black),
                        (int)mesh[mesh.Y - 1, 0].X, (int)mesh[mesh.Y - 1, 0].Y,
                        (int)mesh[mesh.Y - 1, mesh.X - 1].X, (int)mesh[mesh.Y - 1, mesh.X - 1].Y);
                    e.DrawLine(new Pen(Color.Black),
                        (int)mesh[0, mesh.X - 1].X, (int)mesh[0, mesh.X - 1].Y,
                        (int)mesh[mesh.Y - 1, mesh.X - 1].X, (int)mesh[mesh.Y - 1, mesh.X - 1].Y);
                }
                meshs = null;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            points.Clear();
            curves.Clear();
            Quality.Clear();
            Refresh();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curves[choosencurve].accept(this);
            points.Remove(somePoints[1]);
            points.Remove(somePoints[2]);
            curves[choosencurve] = new Line(somePoints[0], somePoints[3]);
            CurveMenuStrip.Close();
            choosencurve = -1;
            Refresh();
        }

        private void bezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x, y;
            curves[choosencurve].accept(this);
            curves[choosencurve].getPoint(0.3, out x, out y);
            points.Add(new Geometry.Point(x, y));
            curves[choosencurve].getPoint(0.6, out x, out y);
            points.Add(new Geometry.Point(x, y));
            curves[choosencurve] = new Bezier(somePoints[0], points[points.Count - 1], points[points.Count - 2], somePoints[1]);
            CurveMenuStrip.Close();
            choosencurve = -1;
            Refresh();
        }

        public void visitLine(Line curve)
        {
            somePoints = new IPoint[2];
            somePoints[0] = curve.l1;
            somePoints[1] = curve.l2;
        }

        public void visitBezier(Bezier curve)
        {
            somePoints = new IPoint[4];
            somePoints[0] = curve.P0;
            somePoints[1] = curve.P1;
            somePoints[2] = curve.P2;
            somePoints[3] = curve.P3;
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void decomposeOnTrianglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            decomPentagon = new PentagonTriangleDecompose();
            

        }

        private void decomposeOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
            decomPentagon = new PentagonDecTetraAndTri();
       
        }

        private void decomposeWithStarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decomPentagon = new PentagonDecSquare();

        }
    }
}

