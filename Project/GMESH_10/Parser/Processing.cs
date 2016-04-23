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
            foreach (Point Point in Points)
            {
                GMESH_Points.Add(new Geometry.Point(Point.x, Point.y));
            }

            foreach (Curve Curve in Curves)
            {
                GMESH_Curves.Add(factory.createICurve(Convert.ToString(Curve.type), GMESH_Points, Curve.special));
            }
        }
    }

    public class PostProcessing : IProcessing, IVisitor
    {
        /// <summary>
        /// Подготавливает данные из программы к записи в документ.
        /// </summary>
        public void convert(ref List<Geometry.ICurve> GMESH_Curves, ref List<Geometry.IPoint> GMESH_Points, ref List<Curve> Curves, ref List<Point> Points)
        {
            Curves.Clear();
            Points.Clear();
            string intermediate_type;
            List<Geometry.IPoint> intermediate_points;
            List<string> intermediate_special;
            List<uint> id;

            foreach (IPoint Point in GMESH_Points)
            {
                Points.Add(new Point(Convert.ToUInt32(GMESH_Points.IndexOf(Point)), Point.X, Point.Y));
            }

            foreach (ICurve Curv in GMESH_Curves)
            {
                Curv.aboutCurve(out intermediate_type, out intermediate_points, out intermediate_special);
                id = new List<uint>();
                foreach(IPoint Point in intermediate_points)
                {
                    id.Add(Convert.ToUInt32(GMESH_Points.Find(x => x == Point)));
                }
                switch(intermediate_type)
                {
                    case ("line"):
                        Curves.Add(new Curve(Curve.type_line.line, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                    case ("astroid"):
                        Curves.Add(new Curve(Curve.type_line.astroid, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                    case ("cardioid"):
                        Curves.Add(new Curve(Curve.type_line.cardioid, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                    case ("circle"):
                        Curves.Add(new Curve(Curve.type_line.circle, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                    case ("cycloid"):
                        Curves.Add(new Curve(Curve.type_line.cycloid, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                    case ("bezier"):
                        Curves.Add(new Curve(Curve.type_line.bezier, Convert.ToUInt32(GMESH_Curves.IndexOf(Curv)), id, intermediate_special));
                        break;
                }
            }
        }

        public void visitLine(Line curve)
        {
            throw new NotImplementedException();
        }

        public void visitBezier(Bezier curve)
        {
            throw new NotImplementedException();
        }

        public void visit(ICurve curve)
        {
            throw new NotImplementedException();
        }
    }
}
