using System.Collections.Generic;
using reactamorty_api.Domains;
using reactamorty_api.Models;

namespace reactamorty_api.DTOs
{
    public class CharactersDto
    {
        public CharacterInfo Info { get; set; }
        public List<CharacterResult> Results { get; set; }
    }
}