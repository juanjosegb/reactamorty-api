using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using reactamorty_api.Domains;
using reactamorty_api.DTOs;
using reactamorty_api.Models;
using reactamorty_api.Services;

namespace reactamorty_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(CharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CharactersDto>> Filter(int page = 1, string name = "", string status = "",
            string species = "", string type = "", string gender = "")
        {
            var characterData = new CharacterData(page == 0 ? 1 : page, name ?? "", status ?? "", species ?? "", type ?? "", gender ?? "");
            var characters = await _characterService.FilterCharacters(characterData);

            if (page > Math.Ceiling((double) characters.Count / 20))
            {
                return BadRequest(new {error = "There is nothing there"});
            }

            var paginatedCharacters = _characterService.PaginateCharacters(characters, characterData);

            var charactersDto = _mapper.Map<List<CharacterResult>, CharactersDto>(paginatedCharacters, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.Info.Pages = Math.Ceiling((double) characters.Count / 20);
                    dest.Info.Next = characterData.Page + 1 > dest.Info.Pages ? null : _characterService.FormatCharacterUrl(characterData, -1);
                    dest.Info.Prev = characterData.Page - 1 < 1 ? null : _characterService.FormatCharacterUrl(characterData, 1);
                });
            });
            return charactersDto;
        }
        
        [HttpGet("{ids}")]
        public async Task<List<CharacterResult>> Get([FromRoute(Name = "ids")]List<int> ids)
        {
            return await _characterService.GetCharacters(ids);
        }
    }
}