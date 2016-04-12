using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Parser
{
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

        public Poligon() { }

        public Poligon(List<Curve> Curves, List<Point> Points)
        {
            this.Curves = Curves;
            this.Points = Points;
        }
    }

    [Serializable]
    public class Curve
    {
        public enum type_line { line, bezier, astroid, cardioid, circle, cycloid }
        [XmlAttribute]
        public uint id;
        [XmlAttribute]
        public type_line type;
        [XmlArrayItem("ID")]
        public List<uint> points;
        [XmlArrayItem]
        public List<string> special;

        public Curve() { }
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

        public Point() { }
        public Point(uint id, double x, double y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}