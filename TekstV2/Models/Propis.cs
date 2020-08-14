using System;
using System.Collections.Generic;

namespace TekstV2.Models
{
    public partial class Propis
    {
        public Propis()
        {
            Clan = new HashSet<Clan>();
            Glava = new HashSet<Glava>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public string TekstPropisa { get; set; }
        public string OblastDelatnost { get; set; }
        public int? IdRubrika { get; set; }
        public int? IdPordrubrika { get; set; }
        public string DatumObjavljivanja { get; set; }
        public string DatumSns { get; set; }
        public string DatumPocetkaPrimene { get; set; }
        public int? IdPropisaRef { get; set; }
        public string Donosilac { get; set; }
        public string GlasiloDatum { get; set; }
        public int? IstorijskaVezaPropisa { get; set; }
        public string Napomena { get; set; }
        public string OsnovZaPrestanak { get; set; }
        public string Podnaslov { get; set; }
        public string PravniOsnov { get; set; }
        public int? PropisId { get; set; }
        public string VrstaPropisa { get; set; }
        public string DatumPrestankaPropisa { get; set; }
        public string DatumPrestankaVerzije { get; set; }
        public int? IdPodpodrubrika { get; set; }
        public string DatumSnsOsnovnogTekstaPropisa { get; set; }
        public int? IdNivoa { get; set; }

        public NivoVazenjaPropisa IdNivoaNavigation { get; set; }
        public Podpodrubrika IdPodpodrubrikaNavigation { get; set; }
        public Podrubrika IdPordrubrikaNavigation { get; set; }
        public Rubrika IdRubrikaNavigation { get; set; }
        public ICollection<Clan> Clan { get; set; }
        public ICollection<Glava> Glava { get; set; }
    }
}
