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
    public class TareaController : Controller
    {
        private readonly BdAppIndevelupContext _context;


        public TareaController(BdAppIndevelupContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaDTO>>> GetTarea()
        {
           
                var listTarea = await _context.Tareas.Include(x=>x.Usuario).ToListAsync();
                 if (listTarea.Count == 0) return NoContent();

                 var listaTareaDTO = listTarea.Select(x => new TareaDTO(x));
                return Ok(listaTareaDTO);
            

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDTO>> GetTareaById(int id)
        {
            try
            {
                var tarea = await _context.Tareas.Include(x => x.Usuario).FirstOrDefaultAsync(x=>x.Id == id);
                if (tarea == null)
                {
                    return NotFound();
                }
                var tareaDTO = new TareaDTO(tarea);
                return Ok(tareaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult> postTarea(TareaDTO tareaDTO)                                                                                                                              
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var usuario = (tareaDTO.Usuario!=null) ? await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == tareaDTO.Usuario.Id) : null;
            var tarea = tareaDTO.ToEntity();
            //if (usuario != null)
            //{
            //    tareaDTO.Usuario = usuario; 
            //}

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetTareaById),
                new { id = tarea.Id },
                 new TareaDTO(tarea));


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TareaDTO>> updateTarea(int id, TareaDTO tareaDTO)
        {
            

            if (id != tareaDTO.Id)
            {
                return BadRequest();
            }
            var tarea = await _context.Tareas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
            Usuario usuario = new Usuario();
            if (tareaDTO.UsuarioId.HasValue)
            {
                 usuario = await _context.Usuarios.FirstOrDefaultAsync(x=>x.Id == tareaDTO.UsuarioId);
            }
            
            // tarea = TareaTo(tareaDTO);
            if (tarea == null)
            {
                return NotFound();
            }


            try
            {
               
                _context.Entry(tarea).CurrentValues.SetValues(tareaDTO);
                await _context.SaveChangesAsync();
                tareaDTO.Usuario = new UsuarioDTO(usuario);

                return Ok(tareaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }



        //private static TareaDTO TareaToDTO(Tarea tarea) =>
        // new TareaDTO
        //{
        // Id = tarea.Id,
        // Usuario = tarea.Usuario,
        // DuracionPlanificada =tarea.DuracionPlanificada,
        // Descripcion = tarea.Descripcion,
        // Codigo=tarea.Codigo
        // };

        //private static Tarea TareaTo(TareaDTO tareaDTO) =>
        //new Tarea
        //{
        //    Usuario = tareaDTO.Usuario,
        //    DuracionPlanificada = tareaDTO.DuracionPlanificada,
        //    Codigo = tareaDTO.Codigo,
        //    Descripcion = tareaDTO.Descripcion,
        //};

        private bool TareaExiste(long id) => _context.Tareas.Any(e => e.Id == id);
    }

    
}
