using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AviaCompany.FileWorkers
{
    public class XmlFileWorker : BaseFileWorker
    {
        public XmlFileWorker(string filePath) : base(filePath)
        {

        }

        public override void Save(List<Plane> planes)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Plane>));
            using (FileStream fileStream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, planes);
            }
        }
        public override List<Plane> Load()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Plane>));
            using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
            {
                return (List<Plane>)formatter.Deserialize(fileStream);                
            }
        }
    }
}
