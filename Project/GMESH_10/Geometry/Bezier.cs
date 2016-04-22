﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geometry
{
    public class Bezier : ICurve
    {
        private IPoint P0;
        private IPoint P1;
        private IPoint P2;
        private IPoint P3;

        public Bezier(IPoint P0, IPoint P1, IPoint P2, IPoint P3)
        {
            this.P0 = P0;
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }

        public void getPoint(double t, out double x, out double y)
        {

            x = this.P0.X * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.X * (1 - t) * (1 - t) + 3 * t * t * P2.X * (1 - t) + t * t * t * P3.X;
            y = this.P0.Y * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.Y * (1 - t) * (1 - t) + 3 * t * t * P2.Y * (1 - t) + t * t * t * P3.Y;
        }
        public void aboutCurve(out string type, out List<IPoint> Points, out List<string> Special)
        {
            type = "bezier";
            Points = new List<IPoint>() { P0, P1, P2, P3 };
            Special = new List<string>();
        }
    }
}

