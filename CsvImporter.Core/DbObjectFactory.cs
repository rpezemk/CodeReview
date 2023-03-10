using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbImporter.Core.Types.DbTypes;

namespace DbImporter.Core.Types;

public class DbObjectFactory
{
    Dictionary<string, Type> _dbObjects = new Dictionary<string, Type>()
    {
        {"DATABASE", typeof(Database) },
        {"TABLE", typeof(Table) },
        {"COLUMN", typeof(Column) }
    };
    
    public DbObject EmitObject(CsvLineModel line)
    {
        DbObject dbObject = null;
        Type type = null;
        if (_dbObjects.ContainsKey(line.Type))
        {
            type = _dbObjects[line.Type];
        }
        else
            type = typeof(UnimplementedDbType);

        dbObject = (DbObject)Activator.CreateInstance(type, new object[] { line });
        return dbObject;
    }
}
