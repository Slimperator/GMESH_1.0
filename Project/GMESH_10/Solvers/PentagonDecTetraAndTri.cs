using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class PentagonDecTetraAndTri : IContourDecompositor, IVisitor
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

        //public IContour[] decomposed(IContour contour)
        //{
        //    for (int i = 0; i < contour.Size; i++)
        //    {
        //        IContour[] cc = decomposed(contour, i);
        //        //оценка.
        //        //рекорд
        //    }

        //}

        public IContour[] decomposed(IContour contour/*, int nom*/)
        {

            List<IPoint> points = new List<IPoint>();
            for (int j = 0; j < contour.Size; j++)
            {
                double x, y;
                contour[j].getPoint(0, out x, out y);
                points.Add(new Point(x, y));
            }

            List<IContour> contours = new List<IContour>();
            double best_grade = -1;
            int best_index = 0;
            for (int i = 0; i < 5; i++)
            {
                // Декомпозиция
                // Треугольник
                List<ICurve> _lines = new List<ICurve>();
                ICurve _cut = new Line(points[2], points[0]);
                _lines.Add(contour[0]);
                _lines.Add(contour[1]);
                _lines.Add(_cut);
                contours.Add(new Contour(_lines));

                // Четырёхугольник
                _lines = new List<ICurve>();
                _lines.Add(contour[2]);
                _lines.Add(contour[3]);
                _lines.Add(contour[4]);
                _lines.Add(_cut);
                contours.Add(new Contour(_lines));
                _lines.Clear();

                // считаем качество
                // Треугольник
                double contour_grade = 0;
                IMeshGen generator = new TriaMeshGen(10, 10);
                List<RegMesh2D> meshs = generator.Generate(contours[0]);
                foreach (RegMesh2D j in meshs)
                    contour_grade += new ArithmMeanGrade().Calculate(j);

                // Четырёхугольник
                generator = new QuadCleverMeshGen(10, 10);
                meshs = generator.Generate(contours[1]);
                contour_grade += new ArithmMeanGrade().Calculate(meshs[0]);
                contour_grade = contour_grade / 4.0;

                if (contour_grade > best_grade)
                {
                    best_grade = contour_grade;
                    best_index = i;
                }

                // мешаем точки
                IPoint tmp_point = points[0];
                points.RemoveAt(0);
                points.Add(tmp_point);
            }

            // в соответствии с индексом восстанавливаем порядок точек
            for (int i = 0; i < best_index; i++)
            {
                IPoint tmp_point = points[0];
                points.RemoveAt(0);
                points.Add(tmp_point);
            }

            List<ICurve> lines = new List<ICurve>();
            ICurve cut = new Line(points[2], points[0]);
            lines.Add(contour[0]);
            lines.Add(contour[1]);
            lines.Add(cut);
            contours.Add(new Contour(lines));

            lines = new List<ICurve>();
            lines.Add(contour[2]);
            lines.Add(contour[3]);
            lines.Add(contour[4]);
            lines.Add(cut);
            contours.Add(new Contour(lines));
            lines.Clear();

            return contours.ToArray();
        }
    }
}
