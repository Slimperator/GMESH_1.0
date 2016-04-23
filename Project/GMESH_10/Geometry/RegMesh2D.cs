using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D
    {
        private IPoint[,] mesh;
        private int len_col;
        private int len_row; // строки

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

        public RegMesh2D(IPoint[,] mesh, int len_row, int len_col)
        {
            this.mesh = mesh;
            this.len_row = len_row;
            this.len_col = len_col;
        }

        public RegMesh2D(int len_row, int len_col)
        {
            this.len_row = len_row;
            this.len_col = len_col;

            mesh = new IPoint[len_row, len_col];
            for (int i = 0; i < len_row; i++)
            {
                for (int j = 0; j < len_col; j++)
                {
                    mesh[i, j] = new Point(0, 0);
                }
            }
        }

        public int X
        {
            get
            {
                return len_col;
            }

        }
        public int Y
        {
            get
            {
                return len_row;
            }

        }
    }
}
