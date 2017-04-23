using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.FileWorkers
{
    public abstract class BaseFileWorker
    {
        protected string _filePath;

        protected BaseFileWorker(string filePath)
        {
            _filePath = filePath;
        }

        public abstract void Save(List<Plane> planes);
        public abstract List<Plane> Load();
    }
}
