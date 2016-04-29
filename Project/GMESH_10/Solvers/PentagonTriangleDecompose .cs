using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    /// name:Александр Климов
    /// date:29.04.2016
    /// class PentagonTriangleDecompose find center of pentagon and decomposes this figure on 5's triangles
    /// </summary>
    public class PentagonTriangleDecompose : IContourDecompositor, IVisitor
    {
        private List<IPoint> pointsOfCurvs;
        private List<IContour> triangles;
        private IPoint[] subPoints;
        private ICurve[] subcurves = new ICurve[2];
        private IPoint pointOfMiddle;
        public IContour[] decomposed(IContour contour)
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
            pointOfMiddle = findCenterTriangle(triangles[triangles.Count - 1]);
            triangles.Clear();
            triangles.Add(new Contour(new List<ICurve> { contour[0], new Line(pointsOfCurvs[1], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[0]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[1], new Line(pointsOfCurvs[2], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[1]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[2], new Line(pointsOfCurvs[3], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[2]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[3], new Line(pointsOfCurvs[4], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[3]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[4], new Line(pointsOfCurvs[0], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[4]) }));
            return triangles.ToArray();
        }
        // находит цетр для треугольника
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

        public void visitLine(Line curve)
        {
            pointsOfCurvs.Add(curve.l1);
            //pointsOfCurvs.Add(curve.l2);
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
