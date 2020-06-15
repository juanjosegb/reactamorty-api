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
    public class LocationsController : ControllerBase
    {
        private readonly reactamortyContext _context;

        public LocationsController(reactamortyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            return await _context.Location.ToListAsync();
        }
    }
}