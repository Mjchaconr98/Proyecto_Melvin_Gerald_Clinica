namespace Proyecto_Melvin_Gerald_Clinica.Models
{
    public class CitaMedica
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? IdPaciente { get; set; }
        public string? IdMedico { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Especialidad { get; set; }
        public string? Estado { get; set; }
    }
}
