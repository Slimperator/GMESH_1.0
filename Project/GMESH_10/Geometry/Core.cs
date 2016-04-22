using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    /// <summary>
    /// Интерфейс определяет внешние контракты объекта "Точка"
    /// </summary>
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
    }
    /// <summary>
    /// Интерфейс определяет внешние контракты объекта "Отрезок"
    /// </summary>
    public interface ISegment : ICurve
    {
        IPoint St { get; set; }
        IPoint Fin { get; set; }
        double Length { get; } 
    }
    /// <summary>
    /// Интерфейс определяет внешние контракты объекта "Кривая"
    /// </summary>
    public interface ICurve : IVisited
    {
        void getPoint(double t, out double x, out double y);
    }
    /// <summary>
    /// Интерфейс определяет внешние контракты объекта "Контур"
    /// </summary>
    public interface IContour
    {
        int Size { get; }
        ICurve this[int i] { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IVisitor
    {
        void visitLine(Line curve);
        void visitBezier(Bezier curve);
        void visit(ICurve curve);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IVisited
    {
        void accept(IVisitor visitor);
    }
}
