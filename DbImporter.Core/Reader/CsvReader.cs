using DbImporter.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DbImporter.Core
{



    public class CsvReader : IDisposable
    {
        private StreamReader streamReader;
        private CsvLineModel currLine;
        public CsvReader(StreamReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader is null!");
            streamReader = reader;
            if(streamReader != null && !streamReader.EndOfStream) 
                streamReader.ReadLine();            
        }

        public CsvReader(Stream stream)
        {
            if(stream == null) 
                throw new ArgumentNullException("stream is null!");
            streamReader = new StreamReader(stream);
            if (!streamReader.EndOfStream)
                streamReader.ReadLine();
        }


        public CsvLineModel CurrLine => currLine;

        public bool CanRead()
        {
            if (streamReader.EndOfStream)
                return false;

            var line = streamReader.ReadLine();

            var values = line.Split(';');
            while (values.Length < 7)
            {
                if (streamReader.EndOfStream)
                    return false;
                line = streamReader.ReadLine();
                values = line.Split(';');
            }

            var csvLine = new CsvLineModel(); 
            csvLine.Type = values[0].Trim().ToUpper(); ;
            csvLine.Name = values[1].Trim().ToUpper(); ;
            csvLine.Schema = values[2].Trim().ToUpper();
            csvLine.ParentName = values[3].Trim().ToUpper();
            csvLine.ParentType = values[4].Trim().ToUpper();
            csvLine.DataType = values[5].ToUpper();
            csvLine.IsNullable = values[6];

            currLine = csvLine;
            return true;
        }

        public void Dispose() => streamReader.Dispose();

    }

}
