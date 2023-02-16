using ConsoleApp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DbObjectFactory
    {
        Dictionary<string, Type> _dbObjects = new Dictionary<string, Type>()
        {
            {"DATABASE", typeof(Database) },
            {"TABLE", typeof(Table) },
            {"COLUMN", typeof(Column) }
        };
        
        public DbObject EmitObject(CsvModel line)
        {
            DbObject figure = null;
            Type figureType = null;
            if (_dbObjects.ContainsKey(line.Type))
            {
                figureType = _dbObjects[line.Type];
            }
            else
                figureType = typeof(UnimplementedDbType);

            figure = (DbObject)Activator.CreateInstance(figureType, new object[] { line });
            return figure;
        }
    }
}
