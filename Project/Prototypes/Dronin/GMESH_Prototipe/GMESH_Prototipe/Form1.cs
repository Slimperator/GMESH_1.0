using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMESH_Prototipe
{
    public partial class Form1 : Form
    {
        private List<Point> Points = new List<Point>();
        private Graphics G;
        private bool Mouse_State = false;
        private int Point_Index = -1;
        public Form1()
        {
            InitializeComponent();
            G = this.CreateGraphics();
        }

        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            switch (e.Button)
            {
                case MouseButtons.Left:

                    foreach (Point P in Points)
                    {
                        if (Math.Pow((P.X - e.X), 2) + Math.Pow((P.Y - e.Y), 2) <= Math.Pow(P.R, 2))
                        {
                            Point_Index = Points.IndexOf(P);
                            break;
                        }
                    }

                    if(Point_Index != -1)
                    {
                        break;
                    }

                    Point Point = new Point(e.X, e.Y);
                    Points.Add(Point);
                    this.Invalidate();                               
                    break;

                case MouseButtons.Right:
                    break;
            }                
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse_State = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point P in Points)
            {
                P.ShowPoint(G, this);
                G.DrawString( 
                    Convert.ToString(Points.IndexOf(P)),
                    new Font(
                       new FontFamily("Arial"),
                       10,
                       FontStyle.Regular,
                       GraphicsUnit.Pixel),
                       new SolidBrush(Color.Black),
                       (P.X + P.R), (P.Y - P.R))
                       ;
                if (Points.IndexOf(P)>=1)
                {
                        G.DrawLine(new Pen(new SolidBrush(Color.Red), 1), Points[Points.IndexOf(P) - 1].X, Points[Points.IndexOf(P) - 1].Y, P.X, P.Y);
                        if (Points.IndexOf(P) == Points.Count - 1)
                            G.DrawLine(new Pen(new SolidBrush(Color.Red), 1), P.X, P.Y, Points[0].X, Points[0].Y);               
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse_State == true && Point_Index != -1)
            {
                Points[Point_Index].X = e.X;
                Points[Point_Index].Y = e.Y;
                this.Invalidate();                            
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Mouse_State = false;
            Point_Index = -1;
        }
    }

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float R = 10;


        public Point(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void ShowPoint (Graphics g, Form Form)
        {
            g.DrawEllipse(new Pen(new SolidBrush(Color.Red), 1), X-R, Y - R, 2*R, 2*R);          
        }
    }
}
