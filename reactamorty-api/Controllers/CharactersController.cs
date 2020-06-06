using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using reactamorty_api.Domains;
using reactamorty_api.Models;
using reactamorty_api.Services;

namespace reactamorty_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(CharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;                                                                                                                                                                                                                                                        
            _mapper = mapper;
        }

        [HttpGet]
        public Task<List<Character>> Get(int page = 0, string name = "", string status = "",
            string species = "", string type = "", string gender = "")
        {
            var characterData =
                new CharacterData(page, name ?? "", status ?? "", species ?? "", type ?? "", gender ?? "");
            var characters = _characterService.GetCharacters(characterData);
            var characterInfo = _mapper.Map<Task<List<Character>>, CharacterInfo>(characters);
            return characters;
        }
    }
}