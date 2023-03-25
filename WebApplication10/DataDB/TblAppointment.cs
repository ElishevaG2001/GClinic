using System;
using System.Collections.Generic;

#nullable disable

namespace Gproject.DataDB
{
    public partial class TblAppointment
    {
        public int IdAppointment { get; set; }
        public int? IdContacts { get; set; }
        public int? IdTreat { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int? Durction { get; set; }
        public string Remark { get; set; }
        public bool? Remined { get; set; }
        public bool? Discount { get; set; }
        public bool? Wait { get; set; }
    }
}
