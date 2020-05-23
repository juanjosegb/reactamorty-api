using System.Collections;
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

        [HttpGet("{page?}")]
        public async Task<ActionResult<IEnumerable>> Get(int? page = null)
        {
            var characters = await _context.Character.ToListAsync();
            return characters;
        }
    }
}