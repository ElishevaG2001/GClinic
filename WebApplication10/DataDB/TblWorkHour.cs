using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication10.DataDB
{
    public partial class TblWorkHour
    {
        public int IdWorkHours { get; set; }
        public int? IdEmployee { get; set; }
        public int? Day { get; set; }
        public int? Shift { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
        public bool? ReglarWork { get; set; }
    }
}
