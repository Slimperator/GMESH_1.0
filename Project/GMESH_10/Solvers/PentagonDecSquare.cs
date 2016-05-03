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
    class PentgonDecSquarecs : IContourDecompositor, IVisitor
    {
                List<IContour> triangles;
        private List<IContour> finalDecompose;//результат декомпозиции
        private List<IPoint> pointsOfCurvs;
        private IPoint[] subPoints;
        private ICurve[] subcurves = new ICurve[2];
        private IPoint pointOfMiddle;

        // находим центр для треугольника
        private IPoint findCenterTriangle(IContour contour)
        {
            IPoint[] points = new IPoint[3];
            for (int i = 0; i < contour.Size; ++i) //находим середины линий
            {
                double x, y;

                contour[i].getPoint(0.5, out x, out y);
                points[i] = new Geometry.Point(x, y);
            }

            return new Geometry.Point((points[0].X + points[1].X + points[2].X) / 3, (points[0].Y + points[1].Y + points[2].Y) / 3);
        }
        // находит центр масс 5ти угольника
        public IPoint prepearToDecompose(IContour contour)
        {
            triangles = new List<IContour>();
            pointsOfCurvs = new List<IPoint>();
            for (int i = 0; i < 5; i++)     //вызываем кривые, чтобы они вызвали метод visitLine и отдали нам свои точки в pointsOfCurvs
            {
                contour[i].accept(this);
            }
            for (int i = 0; i < 2; i++)
            {
                subcurves[i] = new Line(pointsOfCurvs[0], pointsOfCurvs[2 + i]);
            }
            triangles.Add(new Contour(new List<ICurve> { contour[0], contour[1], subcurves[0] }));
            triangles.Add(new Contour(new List<ICurve> { subcurves[0], contour[2], subcurves[1] }));
            triangles.Add(new Contour(new List<ICurve> { subcurves[1], contour[3], contour[4] }));
            subPoints = new Point[triangles.Count];
            foreach (var triangle in triangles)
            {
                subPoints[triangles.IndexOf(triangle)] = findCenterTriangle(triangle);
            }
            subcurves = new ICurve[3];
            subcurves[0] = new Line(subPoints[0], subPoints[1]);
            subcurves[1] = new Line(subPoints[1], subPoints[2]);
            subcurves[2] = new Line(subPoints[2], subPoints[0]);
            triangles.Add(new Contour(new List<ICurve> { subcurves[0], contour[1], contour[2] }));
            return pointOfMiddle = findCenterTriangle(triangles[triangles.Count - 1]);
        }


        public IContour[] decomposed(IContour contour)
        {
            finalDecompose = new List<IContour>();
            pointsOfCurvs = new List<IPoint>();
            double x, y;
            for (int i = 0; i < 5; i++)     //вызываем кривые, чтобы они вызвали метод visitLine и отдали нам свои точки в pointsOfCurvs
            {
                contour[i].getPoint(0, out x, out y);
                pointsOfCurvs.Add(new Point(x, y));
            }
            List<double> lenghts = new List<double>();//массив для длин сторон 5ти угольникка
            List<IPoint> sqPoints = new List<IPoint>();//массив для вершин квадрата
            IPoint center = prepearToDecompose(contour);
            for (int i = 0; i < contour.Size - 1; i++)//находим минимальную длину 
                lenghts.Add(Tools.length(contour[i]));
            double minLenght = lenghts.Min();
            //находим вершины квадрата
            IPoint squarePoint1 = new Point(center.X + minLenght / 3.0, center.Y + minLenght / 3.0);
            IPoint squarePoint2 = new Point(center.X + minLenght / 3.0, center.Y - minLenght / 3.0);
            IPoint squarePoint3 = new Point(center.X - minLenght / 3.0, center.Y - minLenght / 3.0);
            IPoint squarePoint4 = new Point(center.X - minLenght / 3.0, center.Y + minLenght / 3.0);
            sqPoints.Add(squarePoint1);
            sqPoints.Add(squarePoint2);
            sqPoints.Add(squarePoint3);
            sqPoints.Add(squarePoint4);
            //создаём стороны квадрата
            ICurve squareSide1 = new Line(squarePoint1, squarePoint2);
            ICurve squareSide2 = new Line(squarePoint2, squarePoint3);
            ICurve squareSide3 = new Line(squarePoint3, squarePoint4);
            ICurve squareSide4 = new Line(squarePoint4, squarePoint1);
            finalDecompose.Add(new Contour(new List<ICurve> { squareSide1, squareSide2, squareSide3, squareSide4 }));
            List<int> buff = new List<int>();//массив для индесков квадрата(для каждой вершины 5ти угольника находится ближайшая вершина квадрата)
            List<ICurve> preFinCurves = new List<ICurve>();
            for (int i = 0; i < contour.Size; i++)
            {
                for (int j = 0; j < sqPoints.Count - 1; j++)
                    if (Tools.length(new Line(pointsOfCurvs[i], sqPoints[j])) < Tools.length(new Line(pointsOfCurvs[i], sqPoints[j + 1])))
                        buff.Add(j);
                    else buff.Add(j + 1);

            }
            //помещаем в список полученные контуры
            for (int i = 0; i < contour.Size - 1; i++)

                finalDecompose.Add(new Contour(new List<ICurve> { contour[i], new Line(pointsOfCurvs[i], sqPoints[buff[i]]), new Line(pointsOfCurvs[i + 1], sqPoints[buff[i + 1]]), new Line(sqPoints[buff[i]], sqPoints[buff[i + 1]]) }));


            return finalDecompose.ToArray();

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

