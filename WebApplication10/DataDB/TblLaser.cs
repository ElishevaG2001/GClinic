using System;
using System.Collections.Generic;

#nullable disable

namespace Gproject.DataDB
{
    public partial class TblLaser
    {
        public int IdLaser { get; set; }
        public int IdContacts { get; set; }
        public string Area { get; set; }
        public string Ms { get; set; }
        public string SpotSize { get; set; }
        public int? Energy { get; set; }
        public string Reaction { get; set; }
        public DateTime? Date { get; set; }
    }
}
