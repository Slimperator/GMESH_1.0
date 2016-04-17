using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
namespace Parser
{
    public class CurveSimpleFactory
    {
        /// <summary>
        /// Создает экземпляр и вовзращает ссылку на ICurve из Geometry
        /// </summary>
        public ICurve createICurve(string type, List<IPoint> Points, List<string> Special)
        {
            switch (type)
            {
                case ("bezier"):
                    {
                        return new Bezier(Points[0], Points[1], Points[2], Points[3]);
                    }
                case ("line"):
                    {
                        return new Line(Points[0], Points[1]);
                    }
                case ("astroid"):
                    {
                        return new Astroid(Points[0], Convert.ToDouble(Special[0]));
                    }
                case ("cardioid"):
                    {
                        return new Cardioid(Points[0], Convert.ToDouble(Special[0]));
                    }
                case ("circle"):
                    {
                        return new Circle(Points[0], Convert.ToDouble(Special[0]));
                    }
                case ("cycloid"):
                    {
                        return new Cycloid(Points[0], Points[1], Convert.ToBoolean(Special[0]));
                    }
                default:
                    return null;
            }
        }
    }
}
