using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class QuadSimpleMeshGen : IMeshGen
    {
        private int nX;
        private int nY;
        private double hX;
        private double hY;

        /// <summary>
        /// Конструктор "простого" генератора сетки
        /// </summary>
        /// <param name="nX">Количество разбиений по горизонатали(относительно первой кривой)</param>
        /// <param name="nY">Количество разбиений по вертикали(относительно второй кривой)</param>
        public QuadSimpleMeshGen(int nX, int nY)
        {
            this.nX = nX + 1;
            this.nY = nY + 1;
            this.hX = 1.0 / (double)(nX);
            this.hY = 1.0 / (double)(nY);
        }

        public List<RegMesh2D> Generate(IContour contour)
        {
            IPoint[,] points = new Point[this.nY, this.nX];
            ICurve a1 = contour[0];
            ICurve a2 = contour[1];
            ICurve a3 = contour[2];
            ICurve a4 = contour[3];

            for (int i = 0; i < this.nY; i++)
            {
                double xA, yA, xB, yB;
                a4.getPoint(1 - i * hY, out xA, out yA);
                a2.getPoint(i * hY, out xB, out yB);
                ICurve curve = new Relocate(new Morph(a1, a3, i * hY), new Point(xA, yA), new Point(xB, yB));
                for (int j = 0; j < this.nX; j++)
                {
                    double x, y;
                    curve.getPoint(j * hX, out x, out y);
                    points[i, j] = new Point(x, y);
                }
            }// !!!!ЗАГЛУШКА!!!!
            return null;    //new RegMesh2D(points, nX, nY);   // !!!!ЗАГЛУШКА!!!!
            // !!!!ЗАГЛУШКА!!!!
        }
    }
}
