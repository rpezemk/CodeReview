using DbImporter.Core.Types;
using DbImporter.Core.Types.DbTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbImporter
{
    /// <summary>
    /// helpers for managing relations between objects. 
    /// </summary>
    public static class DbHelpers
    {

        private static DbObjectFactory dbObjectFactory;
        public static DbObjectFactory DbObjectFactory
        {
            get
            {
                if (dbObjectFactory == null)
                    dbObjectFactory = new DbObjectFactory();
                return dbObjectFactory;
            }
        }


        /// <summary>
        /// Provides List of nested database objects (database <-- table <-- column)
        /// </summary>
        /// <param name="dbObjects"></param>
        /// <returns></returns>
        public static List<Database> GetDataBases(List<DbObject> dbObjects)
        {
            List<Database> dbList = dbObjects.Where(obj => obj.GetType() == typeof(Database)).Cast<Database>().ToList();
            List<Table> tabList = dbObjects.Where(obj => obj.GetType() == typeof(Table)).Cast<Table>().ToList();
            List<Column> colList = dbObjects.Where(obj => obj.GetType() == typeof(Column)).Cast<Column>().ToList();

            foreach (Database db in dbList)
            {
                db.Tables = tabList.Where(t => t.ParentName.ToUpper() == db.Name.ToUpper()).ToList();
                foreach (Table tab in db.Tables)
                {
                    tab.Columns = colList
                        .Where(t => 
                        t.ParentName.ToUpper() == tab.Name.ToUpper() 
                        && t.Schema.ToUpper() == tab.Schema.ToUpper())
                        .ToList();
                }
            }

            return dbList;
        }


        public static DbObject AsDbObject(this CsvLineModel lineModel) => DbObjectFactory.EmitObject(lineModel);
        
    }

}
