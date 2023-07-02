using System;
using System.Collections.Generic;

#nullable disable

namespace Gproject.DataDB
{
    public partial class Contact
    {
        public int IdContacts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool Sem { get; set; }
        public int? IdTreat { get; set; }
        public string Remark { get; set; }
        public string HowComeUs { get; set; }
    }
}
