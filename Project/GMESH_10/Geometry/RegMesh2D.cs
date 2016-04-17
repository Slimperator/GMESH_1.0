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
                return new Point(0, 0);
            }
            set { }
        }
    }
}
