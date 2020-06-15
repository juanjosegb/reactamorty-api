using System;
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
        private const string UrlBase = "https://localhost:5001/api/";
        private const string Url = UrlBase + "characters?page=";

        public CharacterService(reactamortyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CharacterResult>> FilterCharacters(CharacterData characterData)
        {
            return await _context.Character
                .Where(character => character.Name.ToUpper().Contains(characterData.Name.ToUpper()) &&
                                    character.Status.ToUpper().Contains(characterData.Status.ToUpper()) &&
                                    character.Species.ToUpper().Contains(characterData.Species.ToUpper()) &&
                                    character.Type.ToUpper().Contains(characterData.Type.ToUpper()) &&
                                    character.Gender.ToUpper().Contains(characterData.Gender.ToUpper()))
                .Include(character => character.CharacterHasEpisode)
                .Select(character => new CharacterResult()
                {
                    Id = character.Id,
                    Name = character.Name,
                    Status = character.Status,
                    Type = character.Type,
                    Gender = character.Gender,
                    Origin = new OriginResult(character.OriginNavigation.Name, UrlBase + "location/" + character.OriginNavigation.Id),
                    Location = new LocationResult(character.LocationNavigation.Name, UrlBase + "location/" + character.LocationNavigation.Id),
                    Image = character.Image,
                    Episode = character.CharacterHasEpisode.Select(episode => UrlBase + "episode/" + episode.EpisodeId),
                    Url = UrlBase + "character/" + character.Id,
                    Created = character.Created
                })
                .ToListAsync();
        }
        
        public async Task<List<CharacterResult>> GetCharacters(List<int> ids)
        {
            return await _context.Character
                .Where(character => ids.Contains(character.Id))
                .Include(character => character.CharacterHasEpisode)
                .Select(character => new CharacterResult()
                {
                    Id = character.Id,
                    Name = character.Name,
                    Status = character.Status,
                    Type = character.Type,
                    Gender = character.Gender,
                    Origin = new OriginResult(character.OriginNavigation.Name, UrlBase + "location/" + character.OriginNavigation.Id),
                    Location = new LocationResult(character.LocationNavigation.Name, UrlBase + "location/" + character.LocationNavigation.Id),
                    Image = character.Image,
                    Episode = character.CharacterHasEpisode.Select(episode => UrlBase + "episode/" + episode.EpisodeId),
                    Url = UrlBase + "character/" + character.Id,
                    Created = character.Created
                })
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

        public List<CharacterResult> PaginateCharacters(List<CharacterResult> characters,CharacterData characterData)
        {
            return characters.GetRange(20 * (characterData.Page - 1), 
                Math.Abs(characters.Count - (20 * (characterData.Page - 1))) >= 20 ? 20 : 
                    Math.Abs(characters.Count - (20 * (characterData.Page - 1))));
        }
    }
}