using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Cycloid : ICurve
    {
        private double Radius;                              //Радиус окружности, катящейся по прямой
        private double Agle;                                //Угол параметра t в радианах
        public IPoint Begin { get; private set; }            //Точка начала
        public IPoint End { get; private set; }              //Точка конца
        public bool Convex { get; private set; }             //Впуклость-выпуклость циклоиды
        private IPoint VectorBE;                            //Вектор с началом в точке Begin и концом в точке End         
        /// <summary>
        /// Создает Циклоиду между двумя точками 
        /// с заданной выпуклостью (true - выпуклая, false - впуклая)
        /// </summary>
        public Cycloid(IPoint Begin, IPoint End, bool Convex)
        {
            this.Begin = Begin;
            this.End = End;
            this.Radius = calculationRadius(Begin, End);
            this.Convex = Convex;
            this.VectorBE = vectorCalculate();
        }
        /// <summary>
        /// Возвращает координату точки на поверхности циклоиды 
        /// в момент периода t
        /// </summary>
        public void getPoint(double t, out double x, out double y)
        {
            this.Agle = paramToRadian(t);
            x = getX(this.Agle) + Begin.X;
            y = getY(this.Agle) + Begin.Y;
        }

        /// <summary>
        /// Возвращает Х координату,
        /// t должен быть в радианах
        /// </summary>
        private double getX(double t)
        {
            return this.Radius * (t - Math.Sin(t));
        }
        /// <summary>
        /// Возвращает Y координату,
        /// t должен быть в радианах
        /// </summary>
        private double getY(double t)
        {
            if (Convex)
                return this.Radius * (1 - Math.Cos(t));
            else
                return this.Radius * (1 - Math.Cos(t)) * -1;
        }
        /// <summary>
        /// Возвращает радиус катящейся окружности
        /// </summary>
        private double calculationRadius(IPoint Begin, IPoint End)
        {
            return Math.Sqrt(Math.Pow(this.End.X - this.Begin.X, 2) + Math.Pow(this.End.Y - this.Begin.Y, 2)) / (2 * Math.PI);
        }

        /// <summary>
        /// Возвращает значение угла в радианах, 
        /// при заданном параметре t
        /// от 0 до 1
        /// (от 0 до 2*Pi)
        /// </summary>
        private double paramToRadian(double t)
        {
            return /*((Math.PI) / 180) */ (Math.PI * 2 * t);
        }
        /// <summary>
        /// Возвращает координаты вектора OX рассматриваемого отрезка
        /// </summary>
        private IPoint vectorCalculate()
        {
            return new Point(End.X - Begin.X, End.Y - Begin.Y);
        }
        public void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
//private IPoint VectorOXWorld = new Point(1, 0);     //Базис векторы
//private IPoint VectorOYWorld = new Point(0, 1);     //относительно начала координат
//private IPoint VectorOXFigure;                      //Базис векторы 
//private IPoint VectorOYFigure;                      //которые повернули на AglRotate 
//private double AglRotate;                           //Угол поворота между Базисом Мировых координат и Базисом координат вектора 
/*
/// <summary>
/// Поворачивает базисные вектора так, чтобы OX базиса совпадала с BE 
/// </summary>
private void matrixOfRotate()
{
    VectorOXFigure = new Point(
    VectorOXWorld.X * Math.Cos(AglRotate) - VectorOXWorld.Y * Math.Sin(AglRotate),
    VectorOXWorld.X * Math.Sin(AglRotate) + VectorOXWorld.Y * Math.Cos(AglRotate));

    VectorOYFigure = new Point(
    VectorOYWorld.X * Math.Cos(AglRotate) - VectorOYWorld.Y * Math.Sin(AglRotate),
    VectorOYWorld.X * Math.Sin(AglRotate) + VectorOYWorld.Y * Math.Cos(AglRotate));
}*/
/*
/// <summary>
/// Возвращает значение угла между вектором OX и вектором рассматриваемого отрезка в радианах
/// </summary>
private double aglRotate()
{
    return Math.Acos((VectorOXWorld.X * VectorBE.X + VectorOXWorld.Y * VectorBE.Y) /
        (Math.Sqrt(Math.Pow(VectorBE.X, 2) + Math.Pow(VectorBE.Y, 2)) * Math.Sqrt(Math.Pow(VectorOXWorld.X, 2) + Math.Pow(VectorOXWorld.Y, 2))));
}*/
//x = (getX(this.Agle) + Begin.X) * VectorOXFigure.X + (getY(this.Agle) + Begin.Y) * VectorOYFigure.X;    //Получаем координаты точки
//y = (getX(this.Agle) + Begin.X) * VectorOXFigure.Y + (getY(this.Agle) + Begin.Y) * VectorOYFigure.Y;    //И переносим её в мировые координаты
//this.AglRotate = aglRotate();
//matrixOfRotate();