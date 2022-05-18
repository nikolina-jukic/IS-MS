using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShop.Models
{
    public partial class ArtiklIzvodjac
    {
        public int SifAi { get; set; }
        public int? SifArtikla { get; set; }
        public int? SifIzvodjaca { get; set; }

        public virtual Artikl SifArtiklaNavigation { get; set; }
        public virtual Izvodjac SifIzvodjacaNavigation { get; set; }
    }
}
