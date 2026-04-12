namespace Proyecto_Melvin_Gerald_Clinica.Models
{
    public class Medico
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Nombre { get; set; }
        public string? CedulaProfesional { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? HorarioConsulta { get; set; }
        public string? Estado { get; set; }
    }
}
