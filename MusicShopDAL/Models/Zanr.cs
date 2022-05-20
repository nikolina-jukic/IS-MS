using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShopData
{
    public partial class Zanr
    {
        public Zanr()
        {
            ArtiklZanrs = new HashSet<ArtiklZanr>();
        }

        public int SifZanra { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<ArtiklZanr> ArtiklZanrs { get; set; }
    }
}
