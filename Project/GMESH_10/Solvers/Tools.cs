using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    ///Класс вспомогательных медотов для работы с "Кривыми".
    /// </summary>
    public static class Tools
    {
        private static double h = 0.001;
        /// <summary>
        /// Метод вычисления длины кривой
        /// </summary>
        /// <param name="curve">Кривая, длина которой измеряется данным методом</param>
        /// <returns>Длина кривой</returns>
        public static double length(ICurve curve)
        {
            double x1, y1, x2, y2;
            double result = 0.0;
            for (double t = 0; t < 1; t += h)
            {
                curve.getPoint(t, out x1, out y1);
                curve.getPoint(t + h, out x2, out y2);
                ISegment temp = new Segment(new Point(x1, y1), new Point(x2, y2));
                result += temp.Length;
            }
            return result;
        }
        /// <summary>
        /// Метод вычисляет параметр t, соответствующий длине части дуги
        /// </summary>
        /// <param name="curve">Кривая, для которой вычисляется параметр</param>
        /// <param name="length">Длина, соответствующая искомому параметру</param>
        /// <returns>Параметр t</returns>
        public static double getParam(ICurve curve, double length)
        {
            return length/Tools.length(curve);
        }
    }
}
