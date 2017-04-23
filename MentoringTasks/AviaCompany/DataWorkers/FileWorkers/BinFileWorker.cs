using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.FileWorkers
{
    public class BinFileWorker : BaseFileWorker
    {
        public BinFileWorker(string filePath) : base(filePath)
        {

        }

        public override void Save(List<Plane> planes)
        {
            using (Stream stream = File.Open(_filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, planes);
            }
        }
        public override List<Plane> Load()
        {
            using (Stream stream = File.Open(_filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (List<Plane>)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
