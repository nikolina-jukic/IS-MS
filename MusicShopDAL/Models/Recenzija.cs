using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShopData
{
    public partial class Recenzija
    {
        public int SifRecenzije { get; set; }
        public string Username { get; set; }
        public int? SifArtikla { get; set; }
        public string Tekst { get; set; }

        public virtual Artikl SifArtiklaNavigation { get; set; }
        public virtual Korisnik UsernameNavigation { get; set; }
    }
}
