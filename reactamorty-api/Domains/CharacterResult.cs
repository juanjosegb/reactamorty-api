using System;
using System.Collections.Generic;
using reactamorty_api.Models;

namespace reactamorty_api.Domains
{
    public class CharacterResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public List<Location> Origin { get; set; }
        public List<Location> Location { get; set; }
        public string Image { get; set; }
        public List<string> Episode { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }
    }
}