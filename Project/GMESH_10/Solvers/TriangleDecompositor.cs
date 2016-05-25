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
        private double Max = 0;
        private double alpha = 0.1;
        private IPoint MaxPoint;
        private bool flag = false;
        private IMeshGen gen = new QuadCleverMeshGen(10);
        private IGrade grade = new ArithmMeanGrade();
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
            MaxPoint = L;
            for (int i = 0; i < contour.Size; ++i) //что это должно делать
            {
                List<ICurve> lines = new List<ICurve>();
                int index = i == 0 ? newPoints.Length - 1 : i - 1;

                lines.Add(new SubCurve(contour[i], 0, PART));
                lines.Add(new Line(newPoints[i], L));
                lines.Add(new Line(L, newPoints[index]));
                lines.Add(new SubCurve(contour[index], PART, 1));
                decFigures.Add(new Contour(lines));
                //Max += grade.Calculate(gen.Generate(new Contour(lines))[0]);
            }
            /*
            Max = Max / contour.Size;

            while (flag == false)
            {
                double Local = 0;
                double LocalMax = 0;
                IPoint LocalMaxPoint = null;
                for (int j = 0; j < 4; j++)
                {
                    switch (j) 
                    {
                        case 0:
                            L.X = MaxPoint.X + alpha;
                            L.Y = MaxPoint.Y;
                            break;
                            case 1:
                            L.X = MaxPoint.X - alpha;
                            L.Y = MaxPoint.Y;
                            break;
                            case 2:
                            L.X = MaxPoint.X ;
                            L.Y = MaxPoint.Y + alpha;
                            break;
                            case 3:
                            L.X = MaxPoint.X ;
                            L.Y = MaxPoint.Y - alpha;
                            break;
                    }

                    for (int i = 0; i < contour.Size; ++i) //что это должно делать
                    {
                        List<ICurve> lines = new List<ICurve>();
                        int index = i == 0 ? newPoints.Length - 1 : i - 1;

                        lines.Add(new SubCurve(contour[i], 0, PART));
                        lines.Add(new Line(newPoints[i], L));
                        lines.Add(new Line(L, newPoints[index]));
                        lines.Add(new SubCurve(contour[index], PART, 1));
                        Local += grade.Calculate(gen.Generate(new Contour(lines))[0]);
                    }
                    Local = Local / contour.Size;
                    if (Local > LocalMax)
                    {
                        LocalMax = Local;
                        LocalMaxPoint = L;
                        Local = 0;
                    }
                }
                if (Max - LocalMax < -alpha)
                {
                    Max = LocalMax;
                    MaxPoint = LocalMaxPoint;
                }
                else
                {
                    flag = true;
                }
            }
            
            for (int i = 0; i < contour.Size; ++i) //что это должно делать
            {
                List<ICurve> lines = new List<ICurve>();
                int index = i == 0 ? newPoints.Length - 1 : i - 1;

                lines.Add(new SubCurve(contour[i], 0, PART));
                lines.Add(new Line(newPoints[i], MaxPoint));
                lines.Add(new Line(MaxPoint, newPoints[index]));
                lines.Add(new SubCurve(contour[index], PART, 1));
                decFigures.Add(new Contour(lines));
            }
            */
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
