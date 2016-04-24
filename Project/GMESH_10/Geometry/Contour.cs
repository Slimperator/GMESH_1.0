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
            this.curves = new List<ICurve>(curves); 
        }

        public int Size
        {
            get { return curves.Count(); }
        }

        public ICurve this[int i]
        {
            get
            {
                return curves[i];
            }
            set
            {
                // Пока не нужно
                throw new NotImplementedException();
            }
        }
    }
}
