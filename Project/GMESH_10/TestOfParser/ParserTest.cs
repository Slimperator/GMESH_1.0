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
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    points.Add(new Geometry.Point(x, y));
            for (int i = 0; i < 3; i++)
                curves.Add(new Line(points[i], points[i + 1]));
            // pars.load("C:/Users/Ани/Desktop/GMESH_1.0/Project/GMESH_10/Parser/bin/Debug/xml_out_test.xml");
            // pars.PreProcessing(ref curves, ref points );
            //preproc.convert(ref curves, ref points, ref pars.Gmesh.Poligons[0].Curves, ref pars.Gmesh.Poligons[0].Points);
            postproc.convert(ref curves, ref points, ref pars.Gmesh.Poligons[0].Curves, ref pars.Gmesh.Poligons[0].Points);
            pars.save("C:/Users/Ани/Desktop/GMESH_1.0/Project/GMESH_10/Parser/bin/Debug/xml_test.xml");

       
        }
    }
}
