using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbImporter.Core.Types.DbTypes
{
    internal class UnimplementedDbType : DbObject
    {
        public UnimplementedDbType(CsvLineModel line) : base(line)
        {
        }
    }
}
