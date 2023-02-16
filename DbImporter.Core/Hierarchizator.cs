using DbImporter.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbImporter.Core
{

    /// <summary>
    /// Static class for hierarchization
    /// </summary>
    public class Hierarchizator
    {
        List<CsvLineModel> csvLines;
        public Hierarchizator(List<CsvLineModel> _csvLines)
        {
            this.csvLines = _csvLines.ToList();
        }

        public Hierarchy GetHierarchy()
        {
            Hierarchy hierarchy = new Hierarchy(csvLines.Select(l => l.AsDbObject()).ToList());
            return hierarchy;
        }
    }
}
