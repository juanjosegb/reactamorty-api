using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class Location
    {
        public Location()
        {
            CharacterLocationNavigation = new HashSet<Character>();
            CharacterOriginNavigation = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string Episode { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Character> CharacterLocationNavigation { get; set; }
        public virtual ICollection<Character> CharacterOriginNavigation { get; set; }
    }
}
