﻿namespace DbImporter.Core.Types
{
    public class CsvLineModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }        
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public int NumberOfChildren { get; set; }
    }

}
