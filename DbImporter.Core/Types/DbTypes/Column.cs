using System.Data.Common;

namespace DbImporter.Core.Types.DbTypes
{
    /// <summary>
    /// Column model
    /// </summary>
    public class Column : DbObject
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public Column(CsvLineModel line) : base(line)
        {
            Schema = line.Schema;
            ParentName = line.ParentName;
            ParentType = line.ParentType;
            DataType = line.DataType;
            IsNullable = line.IsNullable;
        }
        public override string ToString()
        {
            return $"\t\tColumn '{Name}' with {DataType} data type {(IsNullable == "1" ? "accepts nulls" : "with no nulls")}";
        }
    }
}
