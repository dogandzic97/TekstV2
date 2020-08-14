using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Rubrika
    {
        public Rubrika()
        {
            Podrubrika = new HashSet<Podrubrika>();
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Podrubrika> Podrubrika { get; set; }
        public ICollection<Propis> Propis { get; set; }
    }
}
