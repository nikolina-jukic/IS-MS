using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShop.Models
{
    public partial class Izvodjac
    {
        public Izvodjac()
        {
            ArtiklIzvodjacs = new HashSet<ArtiklIzvodjac>();
        }

        public int SifIzvodjaca { get; set; }
        public string PunoIme { get; set; }

        public virtual ICollection<ArtiklIzvodjac> ArtiklIzvodjacs { get; set; }
    }
}
