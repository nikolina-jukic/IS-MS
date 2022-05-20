using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShopData
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Narudzbas = new HashSet<Narudzba>();
            Recenzijas = new HashSet<Recenzija>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Lozinka { get; set; }
        public bool Admin { get; set; }

        public virtual ICollection<Narudzba> Narudzbas { get; set; }
        public virtual ICollection<Recenzija> Recenzijas { get; set; }
    }
}
