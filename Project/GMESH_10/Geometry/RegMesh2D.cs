using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D
    {
        private IPoint[,] mesh;
        private int nX;
        private int nY; // строки

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

        public RegMesh2D(IPoint[,] mesh, int nY, int nX)
        {
            this.mesh = mesh;
            this.nY = nY;
            this.nX = nX;
        }

        public RegMesh2D(int nY, int nX)
        {
            this.nY = nY;
            this.nX = nX;

            mesh = new IPoint[nY, nX];
            for (int i = 0; i < nY; i++)
            {
                for (int j = 0; j < nX; j++)
                {
                    mesh[i, j] = new Point(0, 0);
                }
            }
        }

        public int X
        {
            get
            {
                return nX;
            }
            set { }
        }
        public int Y
        {
            get
            {
                return nY;
            }
            set { }
        }
    }
}
