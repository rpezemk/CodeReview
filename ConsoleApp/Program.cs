namespace ConsoleApp
{
    using ConsoleApp.Types;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Michael\\Source\\Repos\\Dataedo\\ConsoleApp\\data.csv";

            using (var reader = new CsvReader(path))
            {
                while (reader.Read())
                {
                    CsvModel model = reader.GetCurr();
                }
            }


            //var reader = new CsvReader(path);
            //var dbObjs = reader.GetDbObjects();
            //var hierarchy = new Hierarchy(dbObjs);
            //Console.WriteLine(hierarchy);
        }
    }
}
