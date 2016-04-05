using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Parser_050416
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xml = new XmlSerializer(typeof(gmesh));
            Stream f;

            f = File.OpenRead("gmesh.xml");
            gmesh g = (gmesh)xml.Deserialize(f);
            f.Close();
            Console.WriteLine(g);





            point[] ps1 = new point[]
            {
                new point(point.type_point.st, 10, 10),
                new point(point.type_point.fin, 20, 20)
            };

            point[] ps2 = new point[]
            {
                new point(point.type_point.st, 10, 10),
                new point(point.type_point.spec, 20, 20),
                new point(point.type_point.spec, 30, 30),
                new point(point.type_point.fin, 40, 40)
            };

            curve[] cs = new curve[2];
            cs[0] = new curve(curve.type_line.line);
            cs[0].points = ps1;
            cs[1] = new curve(curve.type_line.bezier);
            cs[1].points = ps2;

            poligon[] poligs = new poligon[1];
            poligs[0] = new poligon();
            poligs[0].curves = cs;


            gmesh gm = new gmesh();
            gm.poligons = poligs;

            



            SoapFormatter xml_out = new SoapFormatter();
            f = File.Create("xml_out.xml");
            xml.Serialize(f, gm);
            f.Close();
        }
    }
}
