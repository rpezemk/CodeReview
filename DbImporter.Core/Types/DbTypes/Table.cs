using System.Collections.Generic;
using System.Linq;

namespace DbImporter.Core.Types.DbTypes
{
    /// <summary>
    /// db Table model. 
    /// </summary>
    public class Table : DbObject
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public int NumberOfChildren => Columns.Count();
        public List<Column> Columns { get; set; } = new List<Column>();
        public Table(CsvLineModel line) : base(line)
        {
            Schema = line.Schema;
            ParentName = line.ParentName;
            ParentType = line.ParentType;
        }
        public override string ToString()
        {
            return $"\tTable '{Schema}.{Name}' ({NumberOfChildren} columns) + " +
                $"\n{string.Join("\n", Columns.Select(t => t.ToString()))}";
        }
    }

}
