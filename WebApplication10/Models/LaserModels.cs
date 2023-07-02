using System;

namespace Gproject.Models
{
    public class LaserModels
    {
        private string ms;
        private DateTime? date;
        private string spotSize;
        private string area;
        private int? energy;

      

        // l.IdLaser, c.FirstName, c.LastName, c.NumberPhone, l.Ms, l.Date, l.SpotSize, l.Area, l.Energy, l.Reaction 
        public int IdLaser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public string PhoneNumber { get; set; }
        public int Ms { get; set; }
        public DateTime Date { get; set; }

        public int SpotSize { get; set; }
        public int Area { get; set; }
        public int Energy { get; set; }
        public string Reaction { get; set; }


        public LaserModels(int idLaser, string firstName, string lastName, string numberPhone, string ms, DateTime? date, string spotSize, string area, int? energy, string reaction)
        {
            IdLaser = idLaser;
            FirstName = firstName;
            LastName = lastName;
            NumberPhone = numberPhone;
            this.ms = ms;
            this.date = date;
            this.spotSize = spotSize;
            this.area = area;
            this.energy = energy;
            Reaction = reaction;
        }


    }
}
