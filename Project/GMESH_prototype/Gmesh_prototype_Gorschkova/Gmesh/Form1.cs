using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gmesh
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

            public static int rad = 15;

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

            public int R
            { get {return rad;}}

            public void drawPoint(Graphics g)
            {
                g.DrawEllipse(new Pen(Color.Black), this.x - rad, this.y - rad, 2 * rad, 2 * rad); 
            }

            public bool isContain(int x, int y)
            {

                return ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= rad*rad);
            }
        }

        List<Point> points = new List<Point>();

        int isContain(MouseEventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].isContain(e.X, e.Y))
                {
                    return i;
                }
  
            }
            return -1;
        }

         void draw(Graphics g)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].drawPoint(g);
                
               g.DrawString((i + 1).ToString(), new Font("Arial", 10), new SolidBrush (Color.Red), 
                   points[i].X - points[i].R, points[i].Y - points[i].R);

            }

            if (points.Count >= 3)
            {
                for (int j = 1; j <= points.Count; j++)
                    g.DrawLine(new Pen(Color.Black), points[j % points.Count].X, points[j % points.Count].Y,
                        points[(j - 1) % points.Count].X, points[(j - 1) % points.Count].Y);
            }
             
        }


        private void createPoint(object sender, MouseEventArgs e)
        {


            if (isContain(e) == -1)
            {
                Point p = new Point(e.X, e.Y);
                points.Add(p);

                Refresh();
            }
        }

        private void paintPict(object sender, PaintEventArgs e)
        {
           
            Graphics g = this.CreateGraphics();
            draw(g);
        }

        int index =-1;
 

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            index = isContain(e);
            Refresh();
     
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (index == -1)
            {
                return ; 
            }
            else{

                    points[index].X = e.X;
                    points[index].Y = e.Y;
                }
                Refresh();
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            index = -1;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    
    }
}
