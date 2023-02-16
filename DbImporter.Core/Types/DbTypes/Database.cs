using System.Collections.Generic;
using System.Linq;

namespace DbImporter.Core.Types.DbTypes
{
    /// <summary>
    /// Database model
    /// </summary>
    public class Database : DbObject
    {
        public int NumberOfChildren => Tables.Count;
        public Database(CsvLineModel line) : base(line) { }
        public List<Table> Tables { get; set; } = new List<Table>();
        public override string ToString()
        {
            return $"Database '{Name}' ({NumberOfChildren} tables) + " +
                $"\n{string.Join("\n", Tables.Select(t => t.ToString()))}";
        }

    }

}
