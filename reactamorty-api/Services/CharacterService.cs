using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using reactamorty_api.Domains;
using reactamorty_api.Models;

namespace reactamorty_api.Services
{
    public class CharacterService
    {
        private readonly reactamortyContext _context;
        private readonly IMapper _mapper;

        public CharacterService(reactamortyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Character>> GetCharacters(CharacterData characterData)
        {
            return await _context.Character
                .Where(character => character.Name.ToUpper().Contains(characterData.Name.ToUpper()) &&
                                    character.Status.ToUpper().Contains(characterData.Status.ToUpper()) &&
                                    character.Species.ToUpper().Contains(characterData.Species.ToUpper()) &&
                                    character.Type.ToUpper().Contains(characterData.Type.ToUpper()) &&
                                    character.Gender.ToUpper().Contains(characterData.Gender.ToUpper()))
                .ToListAsync();
        }
    }
}