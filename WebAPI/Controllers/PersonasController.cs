using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly dbPruebaTecnicaContext _db;

        public PersonasController(dbPruebaTecnicaContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Personas = await _db.Personas.OrderBy(x => x.Identificador).ToListAsync();

            return Ok(Personas);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetPersona(int id)
        {
            var Persona = await _db.Personas.Where(x => x.Identificador == id).FirstOrDefaultAsync();

            return Ok(Persona);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Personas createPersona)
        {
            if (createPersona == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(createPersona);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
