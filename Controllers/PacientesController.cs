using Microsoft.AspNetCore.Mvc;
using Proyecto_Melvin_Gerald_Clinica.Models;
using Proyecto_Melvin_Gerald_Clinica.Data;
using Proyecto_Melvin_Gerald_Clinica.Authentication;

namespace Proyecto_Melvin_Gerald_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        PacienteQuery pacienteQuery;

        public PacientesController()
        {
            pacienteQuery = new PacienteQuery();
        }

        [HttpGet]
        public List<Paciente> Get()
        {
            List<Paciente> pacientes = pacienteQuery.GetPacientes();
            return pacientes;
        }

        [HttpGet("cedula/{cedula}")]
        public Paciente GetByCedula(string cedula)
        {
            Paciente paciente = pacienteQuery.BuscarPacientePorCedula(cedula);
            return paciente;
        }

        [HttpGet("{id}")]
        public Paciente Get(string id)
        {
            Paciente paciente = pacienteQuery.GetPaciente(id);
            return paciente;
        }

        [HttpPost]
        public void Post([FromBody] Paciente paciente)
        {
            pacienteQuery.AgregarPaciente(paciente);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Paciente paciente)
        {
            pacienteQuery.ActualizarPaciente(id, paciente);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            pacienteQuery.InactivarPaciente(id);
        }
    }
}
