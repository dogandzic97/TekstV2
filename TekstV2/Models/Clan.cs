using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Clan
    {
        public Clan()
        {
            Stav = new HashSet<Stav>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdGlava { get; set; }
        public int? IdPropis { get; set; }
        public string Naslov { get; set; }

        public Glava IdGlavaNavigation { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public ICollection<Stav> Stav { get; set; }
    }
}
