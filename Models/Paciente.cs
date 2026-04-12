namespace Proyecto_Melvin_Gerald_Clinica.Models
{
    public class Paciente
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? EstadoClinico { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
