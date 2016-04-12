using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class QuadGen : IMeshGen
    {
        private int nX;
        private int nY;
        private double hX;
        private double hY;

        public QuadGen (int nX,int nY)
        {
            this.nX = nX+2;
            this.nY = nY+2;
            this.hX = 1.0 /(double)(nX + 1);
            this.hY = 1.0 / (double)(nY + 1);
        }
      
        public Geometry.Point[,] Generate(List<Geometry.ICurve> curves)
        {
            if (curves.Count != 4)
            {
                return null;
            }

            Point[,] points = new Point[this.nY,this.nX];
            ICurve a1 = curves[0];
            ICurve a2 = curves[1];
            ICurve a3 = curves[2];
            ICurve a4 = curves[3];
            for (int i = 0; i <= this.nY; i++)
            {
                double xA, yA, xB, yB;
                a4.getPoint(i * hY, out xA, out yA);
                a2.getPoint(i * hY, out xB, out yB);
                ICurve curve = new Relocate(new Morph(a1, a3, hY), new Point(xA, yA), new Point(xB, yB));
                for (int j = 0; j <= this.nX; j++)
                {
                    double x, y;                   
                    curve.getPoint(j * hX, out x, out y);
                    points[i, j] = new Point(x, y);
                }
            }
            return points;
        }

    }
}
