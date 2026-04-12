using Microsoft.AspNetCore.Mvc;
using Proyecto_Melvin_Gerald_Clinica.Models;
using Proyecto_Melvin_Gerald_Clinica.Data;
using Proyecto_Melvin_Gerald_Clinica.Authentication;

namespace Proyecto_Melvin_Gerald_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        MedicoQuery medicoQuery;

        public MedicosController()
        {
            medicoQuery = new MedicoQuery();
        }

        [HttpGet]
        public List<Medico> Get()
        {
            List<Medico> medicos = medicoQuery.GetMedicos();
            return medicos;
        }

        [HttpGet("{id}")]
        public Medico Get(string id)
        {
            Medico medico = medicoQuery.GetMedico(id);
            return medico;
        }

        [HttpPost]
        public void Post([FromBody] Medico medico)
        {
            medicoQuery.AgregarMedico(medico);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Medico medico)
        {
            medicoQuery.ActualizarMedico(id, medico);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            medicoQuery.InactivarMedico(id);
        }
    }
}
