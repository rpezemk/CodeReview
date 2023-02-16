using DbImporter.Core.Types;
using DbImporter.Core.Types.DbTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbImporter.Core
{
    public class Importer
    {
        StreamReader streamReader;
        public Importer(string path)
        {
            streamReader = new StreamReader(path);
        }

        public Importer(StreamReader reader)
        {
            streamReader = reader;
        }

        public Importer(Stream stream)
        {
            streamReader = new StreamReader(stream);
        }

        public List<CsvLineModel> GetDbObjects()
        {
            List<CsvLineModel> list = new List<CsvLineModel>();
            
            using(var csvReader = new CsvReader(streamReader))
            {
                while (csvReader.CanRead())
                {
                    list.Add(csvReader.CurrLine);
                }
            }

            return list;
        }
    }
}
