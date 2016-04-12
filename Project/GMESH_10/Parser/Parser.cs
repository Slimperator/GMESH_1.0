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
}
