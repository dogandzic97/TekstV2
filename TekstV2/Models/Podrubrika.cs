using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Podrubrika
    {
        public Podrubrika()
        {
            Podpodrubrika = new HashSet<Podpodrubrika>();
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdRubrika { get; set; }

        public Rubrika IdRubrikaNavigation { get; set; }
        public ICollection<Podpodrubrika> Podpodrubrika { get; set; }
        public ICollection<Propis> Propis { get; set; }
    }
}
