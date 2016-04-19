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
        private Gmesh gmesh = new Gmesh();
        private List<Poligon> poligon = new List<Poligon>();
        private List<Curve> curve = new List<Curve>();
        private List<Point> point = new List<Point>();
        private XmlSerializer xml = new XmlSerializer(typeof(Gmesh));
        private IProcessing postProcessing = new PostProcessing();
        private IProcessing preProcessing = new PreProcessing();
        /// <summary>
        /// Сохраняет данные из буфера парсера в xml по указанному адресу
        /// </summary>
        public Parser()
        {
            point.Add(new Point(0, 0, 0));
            curve.Add(new Curve(Curve.type_line.line, 0, null, null));
            poligon.Add(new Poligon(curve, point));
            gmesh.Poligons = poligon;
            
        }
        public void save(string filepath)
        {
            Stream stream = File.Create(filepath);
            xml.Serialize(stream, gmesh);
            stream.Close();
        }
        /// <summary>
        /// Получает данные из xml документа по указанному адресу и записывает их в буфер
        /// </summary>
        public void load(string filepath)
        {
            Stream stream = File.Open(filepath, FileMode.Open);
            this.gmesh = (Gmesh)xml.Deserialize(stream);
            stream.Close();
        }
        /// <summary>
        /// Буфер парсера
        /// </summary>
        public Gmesh Gmesh
        {
            get { return gmesh; }
            set { gmesh = value; }
        }
        /// <summary>
        /// Вовзращает экземпляр класса препроцессинга
        /// </summary>
        public IProcessing PreProcessing
        {
            get { return preProcessing; }
        }
        /// <summary>
        /// Вовзращает экземпляр класса постпроцессинга
        /// </summary>
        public IProcessing PostProcessing
        {
            get { return postProcessing; }
        }
    }    
}
