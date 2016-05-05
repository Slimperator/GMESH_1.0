using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class Contour : IPrepareContour
    {
        private List<ICurve> curves;
        private List<int> partitions;

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

        public int getPartition(int i)
        {
            return partitions[i];
        }

        private void setPartition(int i, int value)
        {
            partitions[i] = value;
        }

        public void createPartitions(double step, double eps)
        {
        }
    }
}
