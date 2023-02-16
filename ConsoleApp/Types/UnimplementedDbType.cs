using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Types
{
    internal class UnimplementedDbType : DbObject
    {
        public UnimplementedDbType(CsvModel line) : base(line)
        {
        }
    }
}
