using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Parser
{
    public interface IProcessing
    {
        void convert(ref List<Geometry.ICurve> GMESH_Curves, ref List<Geometry.IPoint> GMESH_Points, ref List<Curve> Curves, ref List<Point> Points);
    }

    public class PreProcessing : IProcessing
    {
        private CurveSimpleFactory factory = new CurveSimpleFactory();
        /// <summary>
        /// Подготавливает данные из парсера к использованию программой.
        /// </summary>
        public void convert(ref List<Geometry.ICurve> GMESH_Curves, ref List<Geometry.IPoint> GMESH_Points, ref List<Curve> Curves, ref List<Point> Points)
        {
            GMESH_Points.Clear();
            GMESH_Curves.Clear();
            IPoint[] Points_curve;
            foreach (Point Point in Points)
            {
                GMESH_Points.Add(new Geometry.Point(Point.x, Point.y));
            }

            foreach (Curve Curve in Curves)
            {
                Points_curve = new IPoint[Curve.points.Capacity];
                foreach (uint i in Curve.points) { Points_curve[Curve.points.IndexOf(i)] = GMESH_Points[Convert.ToInt32(i)]; }
                GMESH_Curves.Add(factory.createICurve(Convert.ToString(Curve.type), Points_curve, Curve.special));
            }
        }
    }

    public class PostProcessing : IProcessing, IVisitor
    {
        private List<Geometry.IPoint> points_of_curvs;
        private List<string> special_of_curvs;
        private List<uint> id_points_of_curvs;
        private Curve.type_line type = new Curve.type_line();
        /// <summary>
        /// Подготавливает данные из программы к записи в документ.
        /// </summary>
        public void convert(ref List<Geometry.ICurve> GMESH_Curves, ref List<Geometry.IPoint> GMESH_Points, ref List<Curve> Curves, ref List<Point> Points)
        {
            Curves.Clear();
            Points.Clear();
            points_of_curvs = GMESH_Points;

            foreach (IPoint Point in GMESH_Points)
            {
                Points.Add(new Point(Convert.ToUInt32(GMESH_Points.IndexOf(Point)), Point.X, Point.Y));
            }
            foreach (ICurve curve in GMESH_Curves)
            {
                curve.accept(this);
                Curves.Add(new Curve(type, Convert.ToUInt32(GMESH_Curves.IndexOf(curve)),id_points_of_curvs,special_of_curvs));
            }
        }

        public void visitLine(Line curve)
        {
            this.id_points_of_curvs = new List<uint>();
            addPointInIdList(curve.l1);
            addPointInIdList(curve.l2);
            this.type = Curve.type_line.line;
        }

        public void visitBezier(Bezier curve)
        {
            this.id_points_of_curvs = new List<uint>();
            addPointInIdList(curve.P0);
            addPointInIdList(curve.P1);
            addPointInIdList(curve.P2);
            addPointInIdList(curve.P3);
            this.type = Curve.type_line.bezier;
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }

        private void addPointInIdList(IPoint Point)
        {
            uint p = Convert.ToUInt32(points_of_curvs.FindIndex(x => x == Point));
            id_points_of_curvs.Add(p);
        }
    }
}
                /*foreach(IPoint Point in intermediate_points)
                {
                    id.Add(Convert.ToUInt32(GMESH_Points.Find(x => x == Point)));
                }*/