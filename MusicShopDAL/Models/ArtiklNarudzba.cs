using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShop.Models
{
    public partial class ArtiklNarudzba
    {
        public int SifArtNar { get; set; }
        public int? SifArtikla { get; set; }
        public int? SifNarudzbe { get; set; }
        public int? Kolicina { get; set; }

        public virtual Artikl SifArtiklaNavigation { get; set; }
        public virtual Narudzba SifNarudzbeNavigation { get; set; }
    }
}
