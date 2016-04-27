using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class TriangleDecompositor : IContourDecompositor, IVisitor
    {
        private Geometry.IPoint[] pointsOfcurve;
        private const double PART = 0.5;

        public IContour[] decomposed(IContour contour)
        {
            
            Geometry.IPoint[] newPoints = new Geometry.Point[contour.Size]; //пустой массив для середин линий
            List<IContour> decFigures = new List<IContour>(); //пустая коллекция для фигур
            

            for (int i = 0; i < contour.Size; ++i) //находим середины линий
            {
                double x, y;

                contour[i].getPoint(PART, out x, out y);
                newPoints[i] = new Geometry.Point(x, y);
            }

            //поиск точки центра масс
            Geometry.IPoint L = new Geometry.Point((newPoints[0].X + newPoints[1].X + newPoints[2].X) / 3, (newPoints[0].Y + newPoints[1].Y + newPoints[2].Y) / 3);
            
            for (int i = 0; i < contour.Size; ++i) //что это должно делать
            {
                List<ICurve> lines = new List<ICurve>();
                int index = i == 0 ? newPoints.Length - 1 : i - 1;

                lines.Add(new SubCurve(contour[i], 0, PART));
                lines.Add(new Line(newPoints[i], L));
                lines.Add(new Line(L, newPoints[index]));
                lines.Add(new SubCurve(contour[index], PART, 1));

                decFigures.Add(new Contour(lines)); //создаем новый контур на основе полученных линий
            }

            return decFigures.ToArray();
}

        public void visitLine(Line curve)
        {
            pointsOfcurve = new IPoint[4];
            pointsOfcurve[0] = curve.l1;
            pointsOfcurve[1] = curve.l2;
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
