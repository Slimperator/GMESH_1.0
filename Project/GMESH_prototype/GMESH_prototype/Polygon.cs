using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//По дабл-клику удалять точку!
namespace GMESH_prototype
{
    class Polygon
    {
        List<Point> points;
        private int numberOfPoints;

        public Polygon(Point point)
        {
            this.points.Add(point);
            this.numberOfPoints = points.Count;
        }

        public void addPoint(Point point)
        {
            this.points.Add(point);
            this.numberOfPoints = points.Count;
        }

        public void Draw(Graphics g)
        {
            for (int i = 1; i <= this.numberOfPoints; i++)
            {
                this.points[i - 1].Draw(g);
                g.DrawString(i.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black),
                    this.points[i - 1].X - this.points[i - 1].R,
                    this.points[i - 1].Y - this.points[i - 1].R);
            }
            if (this.numberOfPoints >=3)
            {
                for (int i = 1; i < this.numberOfPoints; i++)
                    g.DrawLine(new Pen(Color.Black), this.points[i - 1].X, this.points[i - 1].Y,
                        this.points[i].X, this.points[i].Y);
            }
        }
    }
}
