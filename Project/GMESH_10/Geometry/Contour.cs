using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class Contour : IContour
    {
        private List<ICurve> curves;

        public Contour(List<ICurve> curves)
        {
            this.curves = curves;
        }

        public int Size
        {
            get { throw new NotImplementedException(); }
        }

        public ICurve this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                // Пока не нужно
                throw new NotImplementedException();
            }
        }
    }
}
