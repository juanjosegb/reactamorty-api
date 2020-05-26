using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class LocationHasCharacter
    {
        public int LocationId { get; set; }
        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Location Location { get; set; }
    }
}
