using kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {

        private readonly IMusicService _service;

        public MusicianController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicians(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Zle dane");
            if (await _service.GetMusicianByID(id) is null)
                return NotFound("Nie znaleziono id");

            return Ok(_service.GetMusicianByID(id));
        }


    }
}
