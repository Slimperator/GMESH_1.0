using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D
    {
        private Point[,] mesh;
        private int nX;
        private int nY;

        /// <summary>
        /// Обращение к точке из сетки по индексу
        /// </summary>
        /// <param name="i">Номер строки</param>
        /// <param name="j">Номер столбца</param>
        /// <returns>Объект "точка", лежащий в данной индексированной ячейке</returns>
        public Point this[int i, int j]
        {
            get
            {
                return mesh[i, j];
            }
            set { }
        }

        private ICurve curve1;
        private ICurve curve2;
        private ICurve curve3;
        private ICurve curve4;
        private List<ICurve> curves;
        private int n;
        private int m;

        public List<ICurve> GetCurves()
        {
            return curves;
        }

        public RegMesh2D(int n, int m, ICurve curve1, ICurve curve2, ICurve curve3, ICurve curve4)
        {
            this.curve1 = curve1;
            this.curve2 = curve2;
            this.curve3 = curve3;
            this.curve4 = curve4;
            this.n = n; // делим стороны на части (морфная)
            this.m = m;

            Calculate();
        }

        private void Calculate()
        {
            curves = new List<ICurve>();
            mesh = new Point[n, m];

            curves.Add(curve3);//граничная
            double alpha = 1.0 / (double)n;
            for (int i = 0; i < n; i++, alpha += 1.0 / (double)n)
            {
                Geometry.Point a, b;
                double x, y;
                //первый столбец
                curve2.getPoint(1 - alpha, out x, out y);
                mesh[i, 0] = new Geometry.Point(x, y);
                a = new Geometry.Point(x, y);
                //последний
                curve4.getPoint(alpha, out x, out y);
                mesh[i, m - 1] = new Geometry.Point(x, y);
                b = new Geometry.Point(x, y);
                curves.Add(new Relocate(new Morph(curve1, curve3, alpha), a, b));

                for (int j = 1; j < m - 1; j++)
                {
                    curves[curves.Count - 1].getPoint(alpha, out x, out y);
                    mesh[i, j] = new Geometry.Point(x, y);
                }
            }

            curves.Add(curve2);
            alpha = 1.0 / (double)m;
            for (int i = 0; i < m; i++, alpha += 1.0 / (double)m)
            {
                Geometry.Point a, b;
                double x, y;
                curve1.getPoint(1 - alpha, out x, out y);
                mesh[i, 0] = new Geometry.Point(x, y);
                a = new Geometry.Point(x, y);
                curve3.getPoint(alpha, out x, out y);
                mesh[i, m - 1] = new Geometry.Point(x, y);
                b = new Geometry.Point(x, y);
                curves.Add(new Line(a, b));

                for (int j = 1; j < n - 1; j++)
                {
                    curves[curves.Count - 1].getPoint(alpha, out x, out y);
                    mesh[j, i] = new Geometry.Point(x, y);
                }
            }
        }


    }
}
