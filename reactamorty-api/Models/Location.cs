using System;
using System.Collections.Generic;

namespace reactamorty_api.Models
{
    public partial class Location
    {
        public Location()
        {
            Character = new HashSet<Character>();
            LocationHasCharacter = new HashSet<LocationHasCharacter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string Episode { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Character> Character { get; set; }
        public virtual ICollection<LocationHasCharacter> LocationHasCharacter { get; set; }
    }
}
