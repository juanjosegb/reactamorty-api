using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reactamorty_api.Models;

namespace reactamorty_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly reactamortyContext _context;

        public CharactersController(ILogger<CharactersController> logger, reactamortyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get(int page = 0, string name = "", string status = "",
            string species = "", string type = "", string gender = "")
        {
            var characters = await _context.Character
                .Where(character => character.Name.Contains(name) ||
                                    character.Status.Contains(status) ||
                                    character.Species.Contains(species) ||
                                    character.Type.Contains(type) ||
                                    character.Gender.Contains(gender))
                .ToListAsync();
            return characters;
        }
    }
}