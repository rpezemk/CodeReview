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

    /// <summary>
    /// Class for importing data and transferring data to List of CsvLineModel
    /// </summary>
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

        /// <summary>
        /// So, gimme csvModel list.
        /// </summary>
        /// <returns></returns>
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
