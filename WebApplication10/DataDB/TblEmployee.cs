using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication10.DataDB
{
    public partial class TblEmployee
    {
        public int IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Color { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public int IdTreat { get; set; }
    }
}
