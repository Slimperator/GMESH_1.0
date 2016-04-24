using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using Geometry;
namespace TestOfParses
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Parser.Parser pars = new Parser.Parser();
            IProcessing preproc = pars.PreProcessing;
            IProcessing postproc = pars.PostProcessing;
            List<ICurve> curves = new List<ICurve>();
            List<IPoint> points = new List<IPoint>();
            points.Add(new Geometry.Point(0, 1));
            points.Add(new Geometry.Point(5, 8));
            points.Add(new Geometry.Point(2, 4));
            for (int i = 0; i < 2; i++)
                curves.Add(new Line(points[i], points[i + 1]));
            postproc.convert(ref curves, ref points, ref pars.Gmesh.Poligons[0].Curves, ref pars.Gmesh.Poligons[0].Points);
            pars.save("C:/Users/Ани/Desktop/xml_test.xml");

        }
        [TestMethod]
        public void TestMethod2()
        {
            Parser.Parser pars = new Parser.Parser();
            IProcessing preproc = pars.PreProcessing;
            IProcessing postproc = pars.PostProcessing;
            List<ICurve> curves = new List<ICurve>();
            List<IPoint> points = new List<IPoint>();
            pars.load("C:/Users/Ани/Desktop/xml_test.xml");
            preproc.convert(ref curves, ref points, ref pars.Gmesh.Poligons[0].Curves, ref pars.Gmesh.Poligons[0].Points);
            postproc.convert(ref curves, ref points, ref pars.Gmesh.Poligons[0].Curves, ref pars.Gmesh.Poligons[0].Points);
            pars.save("C:/Users/Ани/Desktop/xml_new_test.xml");
        }
    }
}
