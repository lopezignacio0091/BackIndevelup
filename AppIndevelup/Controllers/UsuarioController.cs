using AccesoDatos;
using AccesoDatos.Modelo;
using AccesoDatos.ModeloDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppIndevelup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly BdAppIndevelupContext _context;
        public UsuarioController(BdAppIndevelupContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var listaUsuarios = await _context.Usuarios
                .Select(x => new UsuarioDTO(x))
                .ToListAsync();
            if (listaUsuarios.Count == 0) return NoContent();


            return Ok(listaUsuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(long id)
        {
            try
            {

                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return new UsuarioDTO(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }


        }


        [HttpPost]
        public async Task<ActionResult> postUsuario(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = usuarioDTO.ToEntity();
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new UsuarioDTO(usuario));
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDTO>> updateUsuario(int id, UsuarioDTO usuarioDTO)
        {

            if (id != usuarioDTO.Id)
            {
                return BadRequest();
            }
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) return NotFound();


            try
            {

                _context.Entry(usuario).CurrentValues.SetValues(usuarioDTO);
                await _context.SaveChangesAsync();
                return Ok(usuarioDTO);
            }
            catch (Exception error)
            {
                return StatusCode(500);
            }


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
