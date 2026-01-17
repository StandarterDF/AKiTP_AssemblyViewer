using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyViewerV2.Utils
{
    public class Types
    {
        public class Assemblies
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string AuthorName { get; set; }
            public string Version { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime LastCheckDate { get; set; }
            public string Description { get; set; }
            public string Information { get; set; }
            public byte[] Photo { get; set; }
        }
        public class Parts
        {
            public int ID { get; set; }
            public int ID_Assembly { get; set; }
            public string PartNumber { get; set; }
            public string Name { get; set; }
            public string Information { get; set; }
            public bool isStandartPart { get; set; }
            public int Count { get; set; }
            public string AuthorName { get; set; }
            public string CheckedBy { get; set; }
            public string Department { get; set; }
            public string Material { get; set; }
            public int Price { get; set; }
            public DateTime CreationDate { get; set; } = DateTime.Now;
            public DateTime LastCheckDate { get; set; } = DateTime.Now;
            public string GOST { get; set; }
            public byte[] Photo { get; set; }
        }
    }
}
