using System;
using System.Collections.Generic;

#nullable disable

namespace Gproject.DataDB
{
    public partial class TblInquiry
    {
        public int IdInquirie { get; set; }
        public int IdAppointment { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public bool? Done { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
    }
}
