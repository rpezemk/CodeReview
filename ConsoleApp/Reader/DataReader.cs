namespace CsvImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;


    public class CsvReader : IDisposable
    {
        private StreamReader streamReader;
        private CsvLineModel currLine;
        public CsvReader(StreamReader reader)
        {
            streamReader = reader;
            if(streamReader != null && !streamReader.EndOfStream) 
                streamReader.ReadLine();            
        }
        public CsvLineModel CurrLine => currLine;

        public bool Read()
        {
            if (streamReader == null)
                throw new Exception("Empty stream reader exception");

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
            csvLine.DataType = values[5];
            csvLine.IsNullable = values[6];

            currLine = csvLine;
            return true;
        }

        public void Dispose()
        {
            streamReader.Dispose();
        }



        //public List<DbObject> GetDbObjects()
        //{
        //    List<CsvLineModel> CsvLines = new List<CsvLineModel>();

        //    var lines = new List<string>();
        //    using (var sr = new StreamReader(fileToImport))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            var line = sr.ReadLine();
        //            if (line.EndsWith(";"))
        //                line += "0";
        //            if (!string.IsNullOrEmpty(line))
        //                lines.Add(line);
        //        }
        //    }


        //    foreach (var line in lines)
        //    {
        //        var values = line.Split(';');
        //        if (values.Length < 7)
        //            continue;

        //        var csvLine = new CsvLineModel();
        //        csvLine.Type = values[0];
        //        csvLine.Name = values[1];
        //        csvLine.Schema = values[2];
        //        csvLine.ParentName = values[3];
        //        csvLine.ParentType = values[4];
        //        csvLine.DataType = values[5];
        //        csvLine.IsNullable = values[6];
        //        CsvLines.Add(csvLine);
        //    }

        //    // clear and correct imported data
        //    foreach (var csvLine in CsvLines)
        //    {
        //        csvLine.Type = csvLine.Type.Trim().ToUpper();
        //        csvLine.Name = csvLine.Name.Trim().ToUpper();
        //        csvLine.Schema = csvLine.Schema.Trim();
        //        csvLine.ParentName = csvLine.ParentName.Trim().ToUpper();
        //        csvLine.ParentType = csvLine.ParentType.Trim().ToUpper();
        //    }

        //    // assign number of children
        //    foreach (var par in CsvLines)
        //        par.NumberOfChildren = CsvLines.Count(ch => ch.ParentType == par.Type);


        //    List<string> outputLines = new List<string>();

        //    DbObjectFactory factory = new DbObjectFactory();
        //    return CsvLines.Select(l => factory.EmitObject(l)).ToList();
        //}


    }

}
