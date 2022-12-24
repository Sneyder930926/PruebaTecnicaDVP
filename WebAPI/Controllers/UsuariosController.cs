using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Request;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly dbPruebaTecnicaContext _db;

        public UsuariosController(dbPruebaTecnicaContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Usuarios = await _db.Usuarios.OrderBy(x => x.Identificador).ToListAsync();

            return Ok(Usuarios);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var Usuario = await _db.Usuarios.Where(x => x.Identificador == id).FirstOrDefaultAsync();

            return Ok(Usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RequestLogin login)
        {
            var Usuario = await _db.Usuarios.Where(x => x.Usuario == login.Usuario && x.Pass == login.Pass).FirstOrDefaultAsync();

            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Usuarios createUsuario)
        {
            if (createUsuario == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(createUsuario);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
