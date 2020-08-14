using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class NivoVazenjaPropisa
    {
        public NivoVazenjaPropisa()
        {
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Propis> Propis { get; set; }
    }
}
