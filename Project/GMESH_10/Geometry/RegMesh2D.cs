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
        private int nY;

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

        public RegMesh2D(IPoint[,] mesh, int nX, int nY)
        {
            this.mesh = mesh;
            this.nX = nX;
            this.nY = nY;
        }

        public RegMesh2D(int nX, int nY)
        {
            this.nX = nX;
            this.nY = nY;

            mesh = new IPoint[nX, nY];
            for (int i = 0; i < nX; i++)
            {
                for (int j = 0; j < nY; j++)
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
