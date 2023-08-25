using APIAdminUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace APIAdminUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private MyDbContext _context;

        public UsuariosController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Users> Get() => _context.User.ToList();

        [HttpPost]
        public async Task<ActionResult<Users>> CrearUsuario(Users usuario)
        {
            _context.User.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarUsuario(string codigo)
        {
            var borrar = await _context.User.FindAsync(codigo);
            if (borrar == null)
            {
                return NotFound();
            }

            _context.User.Remove(borrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> UpdateTodoItem(string codigo, Users usuario)
        {
            if (codigo != usuario.Usuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UsuarioExists(string codigo)
        {
            return _context.User.Any(e => e.Usuario == codigo);
        }
    }
}
