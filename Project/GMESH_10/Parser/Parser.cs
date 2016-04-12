using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Geometry;

namespace Parser
{
    public class Parser
    {
        private Gmesh gmesh;
        private XmlSerializer xml;
        public Parser()
        {
            this.gmesh = new Gmesh();
            xml = new XmlSerializer(typeof(Gmesh));
        }

        public void save(string filepath)
        {
            Stream stream = File.Create(filepath);
            xml.Serialize(stream, gmesh);
            stream.Close();
        }

        public void load(string filepath)
        {
            Stream stream = File.Open(filepath, FileMode.Open);
            this.gmesh = (Gmesh)xml.Deserialize(stream);
            stream.Close();
        }
    }

    public interface Processing
    {
        void convert(List<Point> Points, List<Curve> Curvs, Gmesh Gmesh);
    }

    public class PreProcessing : Processing
    {
        public void convert(List<Point> Points, List<Curve> Curvs, Gmesh Gmesh)
        {
            throw new NotImplementedException();
        }
    }

    public class PostProcessing : Processing
    {
        public void convert(List<Point> Points, List<Curve> Curvs, Gmesh Gmesh)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class Gmesh
    {
        [XmlArrayItem]
        public List<Poligon> Poligons = new List<Poligon>();

        public Gmesh() { }
    }

    [Serializable]
    public class Poligon
    {
        [XmlArrayItem]
        public List<Curve> Curves;
        [XmlArrayItem]
        public List<Point> Points;

        public Poligon (){}

        public Poligon(List<Curve> Curves, List<Point> Points)
        {
            this.Curves = Curves;
            this.Points = Points;
        }
    }

    [Serializable]
    public class Curve
    {
        public enum type_line {line,bezier,astroid,cardioid,circle,cycloid}
        [XmlAttribute]
        public uint id;
        [XmlAttribute]
        public type_line type;
        [XmlArrayItem("ID")]
        public List<uint> points;

        public Curve (){}
        public Curve(type_line type, uint id, List<uint> points)
        {
            this.type = type;
            this.id = id;
            this.points = points;
        }
    }
   
    [Serializable]
    public class Point
    {
        [XmlAttribute]
        public uint id;
        [XmlAttribute]
        public double x { get; set; }
        [XmlAttribute]
        public double y { get; set; }

        public Point (){}
        public Point(uint id, double x, double y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
