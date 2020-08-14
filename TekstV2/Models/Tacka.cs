using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Tacka
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public int? IdStav { get; set; }

        public Stav IdStavNavigation { get; set; }
    }
}
