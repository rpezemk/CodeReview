using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Database : DbObject
    {
        public int NumberOfChildren { get; set; }
        public Database(CsvModel line) : base(line)
        {
            NumberOfChildren = line.NumberOfChildren;
        }
        public List<Table> Tables { get; set; } = new List<Table> ();
        public override string ToString()
        {
            return $"Database '{Name}' ({NumberOfChildren} tables) + " +
                $"\n{string.Join("\n", Tables.Select(t => t.ToString() ))}" ;
        }

    }

}
