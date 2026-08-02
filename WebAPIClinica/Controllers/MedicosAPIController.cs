using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIClinica.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosAPIController : ControllerBase
    {
        // creamos la variable del entityframeworkcore, tiene que ser
        // privada y de sólo lectura
        private readonly Bdclinica2026WebapiContext db;

        // en el constructor recibimos una variable del contexto de
        // EF Core y lo asignamos a nuestra variable privada
        public MedicosAPIController(Bdclinica2026WebapiContext _db)
        {
            db = _db;
        }

        // GET: api/<MedicosAPIController>
        [HttpGet("GetMedicos")]
        public async Task<List<Medico>> GetMedicos()
        {
            // var listado2 = await Task.Run(()=> db.Medicos.ToList());

            var listado = await db.Medicos.ToListAsync();
            return listado;
        }

        // GET api/<MedicosAPIController>/5
        [HttpGet("GetMedico/{id}")]
        public async Task<ActionResult<Medico>> GetMedico(string id)
        {
            var obj = await db.Medicos.FindAsync(id);
            //
            if (obj == null)
            {
                return BadRequest("Codigo No Existe");
            }
            //
            return Ok(obj);
        }

        // POST api/<MedicosAPIController>
        [HttpPost]
        public async Task<ActionResult<Medico>> PostMedico([FromBody] Medico value)
        {
            try
            {
                await db.Medicos.AddAsync(value);
                await db.SaveChangesAsync();
                //
                return Ok("Medico Registrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // PUT api/<MedicosAPIController>/5
        [HttpPut]
        public async Task<ActionResult<Medico>> PutMedico([FromBody] Medico value)
        {
            try
            {
                await Task.Run(()=> db.Medicos.Update(value));
                //
                await db.SaveChangesAsync(); // actualiza la BD
                //
                return Ok("Médico Actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }

        // DELETE api/<MedicosAPIController>/5
        [HttpDelete("DeleteMedico/{id}")]
        public async Task<ActionResult<Medico>> DeleteMedico(string id)
        {
            try
            {
                var buscado = await db.Medicos.FindAsync(id);
                //
                if (buscado == null) 
                {
                    return BadRequest("Error, no existe el Codigo");
                }
                //
                buscado.Eliminado = "Si";
                // actualiza el registro en la BD
                await db.SaveChangesAsync();
                //
                return Ok("Medico Eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
    }
}
