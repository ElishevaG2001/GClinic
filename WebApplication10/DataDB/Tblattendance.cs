using System;
using System.Collections.Generic;

namespace Gproject.DataDB
{
    public class Tblattendance
    {
        public int id_attendance { get; set; }
        public int Id_employee { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? TimeExit { get; set; }
        public DateTime? TimeEnter { get; set; }
        
    }
}
