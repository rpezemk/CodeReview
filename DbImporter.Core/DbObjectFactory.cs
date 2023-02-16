using DbImporter.Core.Types.DbTypes;
using System;
using System.Collections.Generic;

namespace DbImporter.Core.Types
{
    /// <summary>
    /// Object Factory, emits instance of concrete implementation of DbObject. 
    /// </summary>
    public class DbObjectFactory
    {
        Dictionary<string, Type> _dbObjects = new Dictionary<string, Type>()
    {
        {"DATABASE", typeof(Database) },
        {"TABLE", typeof(Table) },
        {"COLUMN", typeof(Column) }
    };


        /// <summary>
        /// emits instance of concrete implementation of DbObject, according to CsvLineModel.Type
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
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

}