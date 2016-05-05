using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    /// Киракосян Ани 
    /// Декомпозиция пятиугольника при помощи квадрата
    /// </summary>
    public class PentagonDecSquare : IContourDecompositor, IVisitor
    {

        private List<IContour> finalDecompose;//результат декомпозиции
        private List<IPoint> pointsOfCurvs;
        private List<ICurve> preDecompose;
        private List<IPoint> generalPoints;


        public IContour[] decomposed(IContour contour)
        {
            pointsOfCurvs = new List<IPoint>();
            generalPoints = new List<IPoint>();
            preDecompose = new List<ICurve>();
            finalDecompose = new List<IContour>();
            for (int i = 0; i < 5; i++)     //вызываем кривые, чтобы они вызвали метод visitLine и отдали нам свои точки в pointsOfCurvs
            {
                contour[i].accept(this);
            }
            preDecompose.Add((new Line(pointsOfCurvs[0], pointsOfCurvs[2])));//0
            preDecompose.Add((new Line(pointsOfCurvs[0], pointsOfCurvs[3])));//1
            preDecompose.Add((new Line(pointsOfCurvs[1], pointsOfCurvs[3])));//2
            preDecompose.Add((new Line(pointsOfCurvs[1], pointsOfCurvs[4])));//3
            preDecompose.Add((new Line(pointsOfCurvs[2], pointsOfCurvs[4])));//4

            generalPoints.Add(findGeneralPoints(preDecompose[0], preDecompose[3]));//1
            generalPoints.Add(findGeneralPoints(preDecompose[0], preDecompose[2]));//2
            generalPoints.Add(findGeneralPoints(preDecompose[4], preDecompose[2]));//3
            generalPoints.Add(findGeneralPoints(preDecompose[1], preDecompose[4]));//4
            generalPoints.Add(findGeneralPoints(preDecompose[3], preDecompose[1]));//5

            //finalDecompose.Add(new Contour(new List<ICurve> { contour[0], new Line(pointsOfCurvs[1], generalPoints[4]), new Line(generalPoints[4], pointsOfCurvs[0]) }));
            //finalDecompose.Add(new Contour(new List<ICurve> { contour[1], new Line(pointsOfCurvs[2], generalPoints[0]), new Line(generalPoints[0], pointsOfCurvs[1]) }));
            finalDecompose.Add(new Contour(new List<ICurve> { contour[2], new Line(pointsOfCurvs[3], generalPoints[3]), new Line(generalPoints[3], generalPoints[1]), new Line(generalPoints[1], pointsOfCurvs[2]) }));
            //finalDecompose.Add(new Contour(new List<ICurve> { contour[3], contour[4], new Line(pointsOfCurvs[0], pointsOfCurvs[3]) }));
            //finalDecompose.Add(new Contour(new List<ICurve> { new Line(generalPoints[0], generalPoints[1]), new Line(generalPoints[1], generalPoints[3]), new Line(generalPoints[3], generalPoints[4]), new Line(generalPoints[4], generalPoints[0]) }));
            
            return finalDecompose.ToArray();
        }

        private IPoint findGeneralPoints(ICurve l1, ICurve l2)
        {
            double x1, y1, x2, y2, x3, y3, x4, y4;
            l1.getPoint(0, out x1, out y1);
            l1.getPoint(1, out x2, out y2);
            l2.getPoint(0, out x3, out y3);
            l2.getPoint(1, out x4, out y4);
            double ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            double x = x1 + ua * (x2 - x1);
            double y = y1 + ua * (y2 - y1);

            return new Point(x, y);
        }

        public void visitLine(Line curve)
        {
            pointsOfCurvs.Add(curve.l1);
        }

        public void visitBezier(Bezier curve)
        {
            throw new NotImplementedException();
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }
    }
}

