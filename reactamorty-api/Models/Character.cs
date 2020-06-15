using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class Character
    {
        public Character()
        {
            CharacterHasEpisode = new HashSet<CharacterHasEpisode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public DateTime? Created { get; set; }
        public int? Origin { get; set; }
        public int? Location { get; set; }

        public virtual Location LocationNavigation { get; set; }
        public virtual Location OriginNavigation { get; set; }
        public virtual ICollection<CharacterHasEpisode> CharacterHasEpisode { get; set; }
    }
}
