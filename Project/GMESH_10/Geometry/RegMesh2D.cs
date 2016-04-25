using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D
    {
        private IPoint[,] mesh;
        private int rows; //rows
        private int cols; // строки

        /// <summary>
        /// Обращение к точке из сетки по индексу
        /// </summary>
        /// <param name="i">Номер строки</param>
        /// <param name="j">Номер столбца</param>
        /// <returns>Объект "точка", лежащий в данной индексированной ячейке</returns>
        public IPoint this[int i, int j]
        {
            get
            {
                return mesh[i, j];
            }
            set
            {
                mesh[i, j] = value;
            }
        }

        public RegMesh2D(IPoint[,] mesh, int cols, int rows)
        {
            this.mesh = mesh;
            this.cols = cols;
            this.rows = rows;
        }

        public RegMesh2D(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;

            mesh = new IPoint[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    mesh[i, j] = new Point(0, 0);
                }
            }
        }

        public int X
        {
            get
            {
                return rows;
            }

        }
        public int Y
        {
            get
            {
                return cols;
            }

        }
    }
}
