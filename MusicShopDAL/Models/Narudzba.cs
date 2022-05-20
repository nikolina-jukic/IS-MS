using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShopData
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            ArtiklNarudzbas = new HashSet<ArtiklNarudzba>();
        }

        public int SifNarudzbe { get; set; }
        public string Username { get; set; }
        public DateTime? Datum { get; set; }

        public virtual Korisnik UsernameNavigation { get; set; }
        public virtual ICollection<ArtiklNarudzba> ArtiklNarudzbas { get; set; }
    }
}
