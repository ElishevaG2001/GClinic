using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication10.DataDB
{
    public partial class TblAccount
    {
        public int IdAccount { get; set; }
        public int IdTreat { get; set; }
        public int IdContacts { get; set; }
        public int? Pay { get; set; }
        public int? Crdite { get; set; }
        public int? Owes { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
