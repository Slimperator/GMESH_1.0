using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class ArithmMeanGrade : IGrade
    {
        public double Calculate(RegMesh2D mesh)
        {
            List<double> average = new List<double>(); //среднее

            for (int i = 0; i < mesh.X - 1; i++)
            {
                for (int j = 0; j < mesh.Y - 1; j++)
                {
                    average.Add(CalculateSquare(mesh[i, j], mesh[i, j + 1], mesh[i + 1, j + 1], mesh[i + 1, j]));
                }
            }

            double sum = 0;
            foreach (double i in average)
            {
                sum += i;
            }

            return sum / (mesh.X * mesh.Y);
        }

        private double CalculateSquare(IPoint p1, IPoint p2, IPoint p3, IPoint p4)
        {
            double alpha = 0.5;

            List<Line> curves = new List<Line>();
            curves.Add(new Line(p1, p2));
            curves.Add(new Line(p2, p3));
            curves.Add(new Line(p3, p4));
            curves.Add(new Line(p4, p1));

            List<double> a = new List<double>();
            foreach (Line curve in curves)
            {
                a.Add(Tools.length(curve));
            }
            //double Lmin = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]);
            //double Lmax = Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            double L = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]) / Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            a.Clear();



            double A1, A2, B1, B2, C1, C2;
            A1 = p1.Y - p2.Y;
            B1 = p2.X - p1.X;
            C1 = p1.X * p2.Y - p2.X * p1.Y;
            A2 = p2.Y - p3.Y;
            B2 = p3.X - p2.X;
            C2 = p2.X * p3.Y - p3.X * p2.Y;
            a.Add(Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)));

            A1 = p2.Y - p3.Y;
            B1 = p3.X - p2.X;
            C1 = p2.X * p3.Y - p3.X * p2.Y;
            A2 = p3.Y - p4.Y;
            B2 = p4.X - p3.X;
            C2 = p3.X * p4.Y - p4.X * p3.Y;
            a.Add(Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)));

            A1 = p3.Y - p4.Y;
            B1 = p4.X - p3.X;
            C1 = p3.X * p4.Y - p4.X * p3.Y;
            A2 = p4.Y - p1.Y;
            B2 = p1.X - p4.X;
            C2 = p4.X * p1.Y - p1.X * p4.Y;
            a.Add(Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)));

            A1 = p4.Y - p1.Y;
            B1 = p1.X - p4.X;
            C1 = p4.X * p1.Y - p1.X * p4.Y;
            A2 = p1.Y - p2.Y;
            B2 = p2.X - p1.X;
            C2 = p1.X * p2.Y - p2.X * p1.Y;
            a.Add(Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)));

            //double Umin = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]);
            //double Umax = Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            double U = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]) / Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);

            a.Clear();


            return (U * alpha + (1 - alpha) * L);
        }
    }
}
