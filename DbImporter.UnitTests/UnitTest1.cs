using DbImporter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DbImporter.UnitTests
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void ImporterTest()
        {
            var input = @"  Type;Name;Schema;ParentName;ParentType;DataType;IsNullable
                            database;AdventureWorks2016_EXT;;;;;
                            Table;SalesTaxRate;Sales;AdventureWorks2016_EXT;Database;NULL;
                            column;ModifiedDate;Sales;SalesPerson;TABLE;datetime;0
                            ";

            var stream = Helpers.GenerateStreamFromString(input);
            Importer importer = new Importer(stream);
            var objs = importer.GetDbObjects();
            var db = objs[0];
            var table = objs[1];
            var col = objs[2];

            Assert.IsTrue(db.Type == "DATABASE");
            Assert.IsTrue(db.Name == "AdventureWorks2016_EXT");

            Assert.IsTrue(table.Type == "TABLE");
            Assert.IsTrue(table.Name == "SalesTaxRate");
            Assert.IsTrue(table.Schema == "Sales");

            Assert.IsTrue(col.Type == "COLUMN");
            Assert.IsTrue(col.Name == "ModifiedDate");
            Assert.IsTrue(col.Schema == "Sales");
            Assert.IsTrue(col.DataType == "datetime".ToUpper());
        }

        [TestMethod]
        public void HierarchizatorTest()
        {
            var input = @"  Type;Name;Schema;ParentName;ParentType;DataType;IsNullable
                            database;AdventureWorks2016_EXT;;;;;
                            Table;SalesPerson;Sales;AdventureWorks2016_EXT;Database;NULL;
                            column;Id;Sales;SalesPerson;TABLE;bigint;0
                            column;ModifiedDate;Sales;SalesPerson;TABLE;datetime;0
                            ";


            var stream = Helpers.GenerateStreamFromString(input);
            Importer importer = new Importer(stream);
            var objs = importer.GetDbObjects();
            var hierarchy = Hierarchizator.GetHierarchy(objs);
            Assert.IsTrue(hierarchy.Databases.Count == 1);
            var db = hierarchy.Databases[0];
            Assert.IsTrue(db.Tables.Count == 1);
            var table0 = db.Tables[0];
            Assert.IsTrue(table0.Columns.Count == 2);
        }



    }
}
