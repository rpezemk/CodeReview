using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbImporter.Core;

namespace ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "..\\..\\data.csv";
            Importer importer = new Importer(path);
            var objects = importer.GetDbObjects();
            var hierarchizator = new Hierarchizator(objects);
            var hierarchy = hierarchizator.GetHierarchy();
            Console.WriteLine(hierarchy);
        }
    }
}
