using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Podpodrubrika
    {
        public Podpodrubrika()
        {
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodrubrike { get; set; }

        public Podrubrika IdPodrubrikeNavigation { get; set; }
        public ICollection<Propis> Propis { get; set; }
    }
}
