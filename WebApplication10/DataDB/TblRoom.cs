using System;
using System.Collections.Generic;

#nullable disable

namespace Gproject.DataDB
{
    public partial class TblRoom
    {
        public int IdRoom { get; set; }
        public string NameRoom { get; set; }
        public int? Treats { get; set; }
    }
}
