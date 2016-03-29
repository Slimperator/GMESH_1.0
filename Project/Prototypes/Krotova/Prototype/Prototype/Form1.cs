using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Form1 : Form
    {
        private bool isClicked = false;
        private int currentClickedPoint = -1;

        public Form1()
        {
            InitializeComponent();
            MouseDown += Form1_MouseDown;
            MouseDoubleClick += Form1_MouseDoubleClick;
        }

        List<Point> pp = new List<Point>();

        void Draw(Graphics g)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (i==currentClickedPoint)
                {
                    pp[i].Fill(g);
                }
                else
                {
                    pp[i].Draw(g);
                }
                
                g.DrawString((i + 1).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), (pp[i].X - pp[i].R), (pp[i].Y - pp[i].R));
            }
            if (pp.Count >= 3)
            {
                for(int i = 1;i <= pp.Count;i++)
                {
                    g.DrawLine(new Pen(Color.Black), pp[i % pp.Count].X, pp[i % pp.Count].Y, pp[(i-1)%pp.Count].X, pp[(i - 1) % pp.Count].Y) ;
                }
            }

        }

        int IsContain(MouseEventArgs e)
        {
            for(int i=0; i<pp.Count;i++)
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
                Point p = new Point(e.X, e.Y);
          
                pp.Add(p);
                Refresh();
            }
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Draw(g);

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
    }
}
