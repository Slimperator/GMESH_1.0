using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    /// "Умный" генератор сетки для четырехугольников. В алгоритмах генерации использует "Tools".
    /// </summary>
    public class QuadCleverMeshGen : IMeshGen
    {
        private Contour contour;
        private RegMesh2D mesh;
        private double lenghtOfPart, alpha;
        private int numOfCurvs, step;
        private double[] vectorOfParam;
        private Point[,] Points;
        public QuadCleverMeshGen(int step, double alpha)
        {
            this.step = step;
            this.alpha = alpha;
            vectorOfParam = new double[step + 1];
        }
        public RegMesh2D Generate(Contour contour)
        {
            this.contour = contour;
            numOfCurvs = contour.Size;
            switch (numOfCurvs)
            {
                case 4:
                    lenghtOfPart = getSizeOfPart(Tools.length(contour[0]));
                    createVectorOfParam();
                    mesh = new RegMesh2D(Convert.ToInt32(Math.Floor(1 / alpha)), step + 1);
                    fillMesh();
                    return mesh;
                default:
                    return null;
            }
        }
        private double getSizeOfPart(double lenghtOfCurve)
        {
            return lenghtOfCurve / step;
        }
        private void createVectorOfParam()
        {
            double intermediate_lenght = 0;
            for (int i = 0; i < step + 1; i++)
            {
                vectorOfParam[i] = Tools.getParam(contour[0], intermediate_lenght);
                intermediate_lenght += lenghtOfPart;
            }
        }
        private void fillMesh()
        {
            for (int i = 0; i < Math.Floor(1 / alpha); i++)
            {
                Point a, b;
                double x, y;
                contour[1].getPoint(1 - alpha * i, out x, out y);
                a = new Geometry.Point(x, y);
                contour[3].getPoint(alpha * i, out x, out y);
                b = new Geometry.Point(x, y);
                ICurve curve = new Relocate(new Morph(contour[0], contour[2], alpha * i), a, b);

                for (int j = 0; j < step + 1; j++)
                {
                    curve.getPoint(vectorOfParam[j], out x, out y);
                    mesh[i, j].X = x;
                    mesh[i, j].Y = y;
                }
            }
        }
    }
}
