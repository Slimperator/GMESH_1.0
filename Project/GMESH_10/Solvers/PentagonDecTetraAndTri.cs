using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class PentagonDecTetraAndTri : IContourDecompositor, IVisitor
    {
        List<IPoint> points;
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
            points.Add(curve.l1);
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

            points = new List<IPoint>();
            for (int i = 0; i < contour.Size; i++) { contour[i].accept(this); }

            List<IContour> contours = new List<IContour>();
            double best_grade = -1;
            int best_index = 0;
            for (int i = 0; i < 5; i++)
            {
                // Декомпозиция
                // Треугольник

                contours.Add(new Contour(new List<ICurve> { contour[0], contour[1], new Line(points[2], points[0])}));

                // Четырёхугольник

                contours.Add(new Contour(new List<ICurve> { contour[2],contour[3], contour[4], new Line(points[0], points[2])}));

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
            contours.Clear();

            contours.Add(new Contour(new List<ICurve> { contour[0], contour[1], new Line(points[2], points[0]) }));

            contours.Add(new Contour(new List<ICurve> { contour[2], contour[3], contour[4], new Line(points[0], points[2]) }));

            return contours.ToArray();
        }
    }
}
