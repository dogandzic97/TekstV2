using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Stav
    {
        public Stav()
        {
            Tacka = new HashSet<Tacka>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public int? IdClan { get; set; }

        public Clan IdClanNavigation { get; set; }
        public ICollection<Tacka> Tacka { get; set; }
    }
}
