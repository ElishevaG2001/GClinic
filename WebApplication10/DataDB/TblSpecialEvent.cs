using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication10.DataDB
{
    public partial class TblSpecialEvent
    {
        public int IdSpecialEvents { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
        public bool Work { get; set; }
    }
}
