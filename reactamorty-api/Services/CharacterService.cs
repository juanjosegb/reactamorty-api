using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        private const string Url = "https://localhost:5001/api/characters?page=";

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

        public string FormatCharacterUrl(CharacterData characterData, int operationMember)
        {
            return $"{Url}{Math.Max(0, characterData.Page - operationMember)}" +
                   $"{(characterData.Name == string.Empty ? string.Empty : "&name=" + characterData.Name)}" +
                   $"{(characterData.Status == string.Empty ? string.Empty : "&status=" + characterData.Status)}" +
                   $"{(characterData.Species == string.Empty ? string.Empty : "&species=" + characterData.Species)}" +
                   $"{(characterData.Type == string.Empty ? string.Empty : "&type=" + characterData.Type)}" +
                   $"{(characterData.Gender == string.Empty ? string.Empty : "&gender=" + characterData.Gender)}";
        }
    }
}