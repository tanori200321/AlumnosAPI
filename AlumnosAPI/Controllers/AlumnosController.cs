using AlumnosAPI.Model;
using AlumnosAPI.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumnosAPI.Controllers
{
    [ApiController, Route("api/alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AlumnosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos() 
        {
            var alumnos = await context.Alumnos.Include(Alumno => Alumno.Materias).ToListAsync();
            return alumnos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await context.Alumnos.Include(Alumno => Alumno.Materias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumno == null) 
            {
                return NotFound();
            }

            return alumno;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Alumno alumno) 
        {
            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody]Alumno alumno)
        {
            var alumnoDb = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            alumnoDb.Nombre = alumno.Nombre;

            context.Alumnos.Update(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alumnoDb = await context.Alumnos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (alumnoDb == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumnoDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
