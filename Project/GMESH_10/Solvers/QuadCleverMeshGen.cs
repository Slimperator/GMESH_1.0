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
        private IContour contour;
        private List<RegMesh2D> mesh;
        private double lenghtOfPart, hX, hY;
        private int numOfCurvs, nX, nY;
        private double[] vectorOfParam;
        public QuadCleverMeshGen(int nX, int nY)
        {
            this.nX = nX + 1;
            this.nY = nY + 1;
            this.hX = 1.0 / (double)(nX);
            this.hY = 1.0 / (double)(nY);
            vectorOfParam = new double[this.nX];
        }
        public QuadCleverMeshGen(int nX)
        {
            this.nX = nX + 1;
            this.nY = nX + 1;
            this.hX = 1.0 / (double)(nX);
            this.hY = 1.0 / (double)(nX);
            vectorOfParam = new double[this.nX];
        }
        public List<RegMesh2D> Generate(IContour contour)
        {
            this.mesh = new List<RegMesh2D>();
            this.contour = contour;
            numOfCurvs = contour.Size;
            switch (numOfCurvs)
            {
                case 4:
                    lenghtOfPart = getSizeOfPart(Tools.length(contour[0]));
                    createVectorOfParam();
                    mesh.Add(new RegMesh2D(nY, nX));
                    fillMesh();
                    return mesh;
                default:
                    return null;
            }
        }
        private double getSizeOfPart(double lenghtOfCurve)
        {
            return lenghtOfCurve * hX;
        }
        private void createVectorOfParam()
        {
            double intermediate_lenght = 0;
            for (int i = 0; i < nX; i++)
            {
                vectorOfParam[i] = Tools.getParam(contour[0], intermediate_lenght);
                intermediate_lenght += lenghtOfPart;
            }
        }
        private void fillMesh()
        {
            for (int i = 0; i < nY; i++)
            {
                Point a, b;
                double x, y;
                contour[1].getPoint(1 - hY * i, out x, out y);
                a = new Geometry.Point(x, y);
                contour[3].getPoint(hY * i, out x, out y);
                b = new Geometry.Point(x, y);
                ICurve curve = new Relocate(new Morph(contour[0], contour[2], hY * i), a, b);

                for (int j = 0; j < nX; j++)
                {
                    curve.getPoint(vectorOfParam[j], out x, out y);
                    mesh[0][i, j].X = x;
                    mesh[0][i, j].Y = y;
                }
            }
        }
    }
}