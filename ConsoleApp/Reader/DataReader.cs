namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;


    public class CsvReader : IDbObjectsReader
    {
        string fileToImport;
        public CsvReader(string fileToImport)
        {
            this.fileToImport = fileToImport;
        }



        public List<DbObject> GetDbObjects()
        {
            List<CsvModel> CsvLines = new List<CsvModel>();

            var lines = new List<string>();
            using (var sr = new StreamReader(fileToImport))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.EndsWith(";"))
                        line += "0";
                    if(!string.IsNullOrEmpty(line))
                        lines.Add(line);
                }
            }

            
            foreach (var line in lines)
            {
                var values = line.Split(';');
                if (values.Length < 7)
                    continue;

                var csvLine = new CsvModel();
                csvLine.Type = values[0];
                csvLine.Name = values[1];
                csvLine.Schema = values[2];
                csvLine.ParentName = values[3];
                csvLine.ParentType = values[4];
                csvLine.DataType = values[5];
                csvLine.IsNullable = values[6];
                CsvLines.Add(csvLine);
            }

            // clear and correct imported data
            foreach (var csvLine in CsvLines)
            {
                csvLine.Type = csvLine.Type.Trim().ToUpper();
                csvLine.Name = csvLine.Name.Trim().ToUpper();
                csvLine.Schema = csvLine.Schema.Trim();
                csvLine.ParentName = csvLine.ParentName.Trim().ToUpper();
                csvLine.ParentType = csvLine.ParentType.Trim().ToUpper();
            }

            // assign number of children
            foreach (var par in CsvLines)
                par.NumberOfChildren = CsvLines.Count(ch => ch.ParentType == par.Type);


            List<string> outputLines = new List<string>();

            DbObjectFactory factory = new DbObjectFactory();
            return CsvLines.Select(l => factory.EmitObject(l)).ToList();
        }

        internal CsvModel GetCurr()
        {
            throw new NotImplementedException();
        }

        internal bool Read()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }

}
