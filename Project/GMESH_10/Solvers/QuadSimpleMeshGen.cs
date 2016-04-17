using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class QuadSimpleMeshGen : IMeshGen
    {
        private int nX;
        private int nY;
        private double hX;
        private double hY;

        public QuadSimpleMeshGen (int nX,int nY)
        {
            
        }

        public Point[,] Generate(Contour contour)
        {
            // Раньше мы принимали массив кривых "curves"
            // Теперь он инкапсюлирован в контуре. 
            // Надо переделать согласно такой конструкции не меняя сам алгоритм
            return null;
        }
    }
}
