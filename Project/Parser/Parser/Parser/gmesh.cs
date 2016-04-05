using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Parser_050416
{
    [Serializable]
    public class gmesh
    {
        [XmlArrayItem]
        public poligon[] poligons;

        public gmesh() { }
    }

    [Serializable]
    public class poligon
    {
        [XmlArrayItem]
        public curve[] curves;

        public poligon() { }
    }

    [Serializable]
    public class curve
    {
        public enum type_line { line, bezier };
        [XmlAttribute]
        public type_line type;
        [XmlArrayItem]
        public point[] points;


        public curve() { }
        public curve(type_line type) 
        {
            this.type = type;
        }
    }

    [Serializable]
    public class point
    {
        [XmlAttribute]
        public int x;
        [XmlAttribute]
        public int y;
        public enum type_point { st, spec, fin };
        [XmlAttribute]
        public type_point type;

        public point() { }
        public point(type_point type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }
}
