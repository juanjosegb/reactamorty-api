using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class CharacterHasEpisode
    {
        public int CharacterId { get; set; }
        public int EpisodeId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Episode Episode { get; set; }
    }
}
