using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class Episode
    {
        public Episode()
        {
            CharacterHasEpisode = new HashSet<CharacterHasEpisode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string Episode1 { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<CharacterHasEpisode> CharacterHasEpisode { get; set; }
    }
}
