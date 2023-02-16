using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// helpers for managing relations between objects. 
    /// </summary>
    public static class CsvHelpers
    {
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
                db.Tables = tabList.Where(t => t.ParentName == db.Name).ToList();
                foreach(Table tab in db.Tables)
                {
                    tab.Columns = colList.Where(t => t.ParentName == tab.Name && t.Schema == tab.Schema).ToList();
                }
            }

            return dbList;
        }
    }
}
