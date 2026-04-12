using Microsoft.AspNetCore.Mvc;
using Proyecto_Melvin_Gerald_Clinica.Models;
using Proyecto_Melvin_Gerald_Clinica.Data;
using Proyecto_Melvin_Gerald_Clinica.Authentication;

namespace Proyecto_Melvin_Gerald_Clinica.Controllers
{
    [BasicAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesClinicosController : ControllerBase
    {
        HistorialClinicoQuery historialQuery;

        public HistorialesClinicosController()
        {
            historialQuery = new HistorialClinicoQuery();
        }

        [HttpGet]
        public List<HistorialClinico> Get()
        {
            List<HistorialClinico> historiales = historialQuery.GetHistoriales();
            return historiales;
        }

        [HttpGet("{id}")]
        public HistorialClinico Get(string id)
        {
            HistorialClinico historial = historialQuery.GetHistorial(id);
            return historial;
        }

        [HttpPost]
        public void Post([FromBody] HistorialClinico historial)
        {
            historialQuery.AgregarHistorial(historial);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] HistorialClinico historial)
        {
            historialQuery.ActualizarHistorial(id, historial);
        }

        // Delete no se implementa segÃºn reglas de negocio
    }
}
