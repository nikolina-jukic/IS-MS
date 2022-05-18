using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShop.Models
{
    public partial class ArtiklZanr
    {
        public int SifAz { get; set; }
        public int? SifArtikla { get; set; }
        public int? SifZanra { get; set; }

        public virtual Artikl SifArtiklaNavigation { get; set; }
        public virtual Zanr SifZanraNavigation { get; set; }
    }
}
