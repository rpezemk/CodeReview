using DbImporter.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbImporter.Core
{
    public static class Hierarchizator
    {
        public static Hierarchy GetHierarchy(List<CsvLineModel> csvLines)
        {
            Hierarchy hierarchy = new Hierarchy(csvLines.Select(l => l.AsDbObject()).ToList());
            return hierarchy;
        }
    }
}
