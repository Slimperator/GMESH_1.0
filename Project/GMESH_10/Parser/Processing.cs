using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Parser
{
    public interface Processing
    {
        void convert(List<Geometry.ICurve> GMESH_Curves, List<Curve> Curves, List<Point> Points);
    }

    public class PreProcessing : Processing
    {
        public void convert(List<Geometry.ICurve> GMESH_Curves, List<Curve> Curves, List<Point> Points)
        {
            List<Geometry.IPoint> GMESH_Points = new List<IPoint>();
            foreach (Point Point in Points)
            {
                GMESH_Points.Add(new Geometry.Point(Point.x, Point.y));
            }

            foreach (Curve Curve in Curves)
            {
                //GMESH_Curves.Add(new Curve.type_line());
            }
        }
    }

    public class PostProcessing : Processing
    {
        public void convert(List<Geometry.ICurve> GMESH_Curves, List<Curve> Curves, List<Point> Points)
        {
            throw new NotImplementedException();
        }
    }
}
