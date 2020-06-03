using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reactamorty_api.Domains;
using reactamorty_api.Models;
using reactamorty_api.Services;

namespace reactamorty_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly reactamortyContext _context;
        private readonly CharacterService _characterService;

        public CharactersController(ILogger<CharactersController> logger, reactamortyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get(int page = 0, string name = "", string status = "",
            string species = "", string type = "", string gender = "")
        {
            var characterData = new CharacterData(page, name ?? "", status ?? "", species ?? "", type ?? "", gender ?? "");
            var characterInfo = _characterService.getExtraInformation(characterData);
            var characters = await _context.Character
                .Where(character => character.Name.ToUpper().Contains(cleanedName.ToUpper()) &&
                                    character.Status.ToUpper().Contains(cleanedStatus.ToUpper()) &&
                                    character.Species.ToUpper().Contains(cleanedSpecies.ToUpper()) &&
                                    character.Type.ToUpper().Contains(cleanedType.ToUpper()) &&
                                    character.Gender.ToUpper().Contains(cleanedGender.ToUpper()))
                .ToListAsync();
            return characters;
        }
    }
}