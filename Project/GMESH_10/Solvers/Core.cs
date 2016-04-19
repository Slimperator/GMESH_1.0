using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    /// <summary>
    /// Интерфейс, описывающий внешние контракты генераторов сеток
    /// </summary>
    public interface IMeshGen
    {
        Point[,] Generate(Contour contour);
    }
    /// <summary>
    /// Интерфейс, описывающий внешние контракты декомпозиторов сеток
    /// </summary>
    public interface IContourDecompositor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contour"></param>
        /// <returns></returns>
        IContour[] decomposed(IContour contour);
    }
    /// <summary>
    /// Интерфейс, описывающий внешние контракты для оценки качества сетки
    /// </summary>
    public interface IGrade
    {
        double Calculate(RegMesh2D mesh);
    }
}
