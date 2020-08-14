using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Glava
    {
        public Glava()
        {
            Clan = new HashSet<Clan>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPropisa { get; set; }
        public string NaslovGlave { get; set; }

        public Propis IdPropisaNavigation { get; set; }
        public ICollection<Clan> Clan { get; set; }
    }
}
