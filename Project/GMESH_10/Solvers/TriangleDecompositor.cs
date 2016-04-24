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

        public IContour[] decomposed(IContour contour)
        {
            Geometry.IPoint[] newPoints = new Geometry.Point[contour.Size]; //тут чисто середины линий
            List<IContour> decFigures = new List<IContour>();
            

            for (int i = 0; i < contour.Size; ++i) //находим середины линий
            {
                double x = 0;
                double y = 0;

                contour[i].getPoint(0.5, out x, out y);
                newPoints[i] = new Geometry.Point(x, y);
            }

            Geometry.IPoint L = new Geometry.Point((newPoints[0].X + newPoints[1].X + newPoints[2].X) / 3, (newPoints[0].Y + newPoints[1].Y + newPoints[2].Y) / 3);
            //выше поиск точки центра масс
            for (int i = 0; i < contour.Size; ++i) //что это должно делать
            {
                contour[i].accept(this); //получаем точки
                pointsOfcurve[1] = newPoints[i];// меняем точку конца кривой на точку середины кривой
                pointsOfcurve[2] = L;// добавляем центр масс для всего треугольника
                if (i == 0)
                {
                    pointsOfcurve[3] = newPoints[contour.Size - 1];
                }
                else
                {
                    pointsOfcurve[3] = newPoints[i - 1];
                }

                List<ICurve> lines = new List<ICurve>();

                for (int j = 0; j < 4; ++j)
                {
                    if (j == 3) lines.Add(new Line(pointsOfcurve[j], pointsOfcurve[0]));
                    else
                    lines.Add(new Line(pointsOfcurve[j], pointsOfcurve[j + 1]));
                }
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
