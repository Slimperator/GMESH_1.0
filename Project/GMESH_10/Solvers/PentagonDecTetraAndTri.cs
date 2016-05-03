using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    class PentagonDecTetraAndTri : IContourDecompositor, IVisitor
    {
        public void visitBezier(Bezier curve)
        {
            throw new NotImplementedException();
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }

        public void visitLine(Line curve)
        {
            throw new NotImplementedException();
        }

        public IContour[] decomposed(IContour contour)
        {
            List<IContour> contours = new List<IContour>();

            // Получаем точки пятиугольника
            List<IPoint> points = new List<IPoint>();
            for (int i = 0; i < contour.Size; i++)
            {
                double x, y;
                contour[i].getPoint(0, out x, out y);
                points.Add(new Point(x, y));
            }

            // Декомпозиция
            // Треугольник
            List<ICurve> lines = new List<ICurve>();
            lines.Add(new Line(points[0], points[1]));
            lines.Add(new Line(points[1], points[2]));
            lines.Add(new Line(points[2], points[0]));
            contours.Add(new Contour(lines));
            lines.Clear();

            // Четырехугольник
            lines.Add(new Line(points[0], points[2]));
            lines.Add(new Line(points[2], points[3]));
            lines.Add(new Line(points[3], points[4]));
            lines.Add(new Line(points[4], points[0]));
            contours.Add(new Contour(lines));
            lines.Clear();

            return contours.ToArray();
        }
    }
}
