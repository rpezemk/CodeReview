using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Types
{
    public class Hierarchy
    {
        public List<Database> Databases { get; set; } = new List<Database>();
        public Hierarchy(List<DbObject> objects)
        {
            var dbs = CsvHelpers.GetDataBases(objects);
            Databases = dbs;
        }

        public override string ToString() => String.Join("\n", Databases.Select(db => db.ToString()));
    }
}
