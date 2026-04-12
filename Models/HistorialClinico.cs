namespace Proyecto_Melvin_Gerald_Clinica.Models
{
    public class HistorialClinico
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? IdPaciente { get; set; }
        public string? IdMedico { get; set; }
        public string? Diagnostico { get; set; }
        public string? Tratamiento { get; set; }
        public DateTime? FechaConsulta { get; set; } = DateTime.UtcNow;
    }
}
