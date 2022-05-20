using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShopData
{
    public partial class Artikl
    {
        public Artikl()
        {
            ArtiklIzvodjacs = new HashSet<ArtiklIzvodjac>();
            ArtiklNarudzbas = new HashSet<ArtiklNarudzba>();
            ArtiklZanrs = new HashSet<ArtiklZanr>();
            Recenzijas = new HashSet<Recenzija>();
        }

        public int SifArtikla { get; set; }
        public string Ime { get; set; }
        public int? SifVrste { get; set; }
        public int? Godina { get; set; }
        public double? Cijena { get; set; }

        public virtual VrstaArtikla SifVrsteNavigation { get; set; }
        public virtual ICollection<ArtiklIzvodjac> ArtiklIzvodjacs { get; set; }
        public virtual ICollection<ArtiklNarudzba> ArtiklNarudzbas { get; set; }
        public virtual ICollection<ArtiklZanr> ArtiklZanrs { get; set; }
        public virtual ICollection<Recenzija> Recenzijas { get; set; }
    }
}
