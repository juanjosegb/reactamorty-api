﻿using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using reactamorty_api.Models;

namespace reactamorty_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly reactamortyContext _context;

        public EpisodesController(ILogger<CharactersController> logger, reactamortyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            return await _context.Episode.ToListAsync();
        }
    }
}