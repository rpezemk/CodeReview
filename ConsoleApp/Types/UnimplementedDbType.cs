﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvImporter.Types
{
    internal class UnimplementedDbType : DbObject
    {
        public UnimplementedDbType(CsvLineModel line) : base(line)
        {
        }
    }
}
