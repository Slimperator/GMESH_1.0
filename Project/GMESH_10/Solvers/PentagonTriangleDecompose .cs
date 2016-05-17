using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    /// name:Александр Климов
    /// date:04.05.2016
    /// class PentagonTriangleDecompose find center of pentagon and decomposes this figure on 5's triangles
    /// </summary>
    public class PentagonTriangleDecompose : IContourDecompositor, IVisitor
    {
        private List<IPoint> pointsOfCurvs;
        private List<IContour> triangles;        
        private IPoint pointOfMiddle;
        public IContour[] decomposed(IContour contour)
        {
            triangles = new List<IContour>();
            
            pointOfMiddle = findCenterPentagon(contour);
            // create five triangles for pentagon
            triangles.Add(new Contour(new List<ICurve> { contour[0], new Line(pointsOfCurvs[1], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[0]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[1], new Line(pointsOfCurvs[2], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[1]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[2], new Line(pointsOfCurvs[3], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[2]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[3], new Line(pointsOfCurvs[4], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[3]) }));
            triangles.Add(new Contour(new List<ICurve> { contour[4], new Line(pointsOfCurvs[0], pointOfMiddle), new Line(pointOfMiddle, pointsOfCurvs[4]) }));
            return triangles.ToArray();
        }
        // находит цетр для треугольника
        /// <summary>
        /// chahged method for find center of pentagon
        /// </summary>
        /// <param name="contour"></param>
        /// <returns> contour</returns>
        private IPoint findCenterPentagon(IContour contour)
        {
            pointsOfCurvs = new List<IPoint>();
            IPoint[] points = new IPoint[3];
            for (int i = 0; i < 5; ++i)
            {
                contour[i].accept(this);
            }

            return new Geometry.Point((pointsOfCurvs[0].X + pointsOfCurvs[1].X + pointsOfCurvs[2].X + pointsOfCurvs[3].X + pointsOfCurvs[4].X) / 5, (pointsOfCurvs[0].Y + pointsOfCurvs[1].Y + pointsOfCurvs[2].Y + pointsOfCurvs[3].Y + pointsOfCurvs[4].Y) / 5);
        }

        public void visitLine(Line curve)
        {
            pointsOfCurvs.Add(curve.l1);
            //pointsOfCurvs.Add(curve.l2);
        }

        public void visitBezier(Bezier curve)
        {
            pointsOfCurvs.Add(curve.P0);
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }
    }
}
