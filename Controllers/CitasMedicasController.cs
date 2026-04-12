using Microsoft.AspNetCore.Mvc;
using Proyecto_Melvin_Gerald_Clinica.Models;
using Proyecto_Melvin_Gerald_Clinica.Data;
using Proyecto_Melvin_Gerald_Clinica.Authentication;

namespace Proyecto_Melvin_Gerald_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class CitasMedicasController : ControllerBase
    {
        CitaMedicaQuery citaQuery;

        public CitasMedicasController()
        {
            citaQuery = new CitaMedicaQuery();
        }

        [HttpGet]
        public List<CitaMedica> Get()
        {
            List<CitaMedica> citas = citaQuery.GetCitas();
            return citas;
        }

        [HttpGet("{id}")]
        public CitaMedica Get(string id)
        {
            CitaMedica cita = citaQuery.GetCita(id);
            return cita;
        }

        [HttpPost]
        public void Post([FromBody] CitaMedica cita)
        {
            citaQuery.AgregarCita(cita);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CitaMedica cita)
        {
            citaQuery.ActualizarCita(id, cita);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            citaQuery.InactivarCita(id);
        }
    }
}
