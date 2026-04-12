using Proyecto_Melvin_Gerald_Clinica.Models;
using System.Text.Json;

namespace Proyecto_Melvin_Gerald_Clinica.Data
{
    public class CitaMedicaQuery
    {
        private List<CitaMedica> citas;
        private const string RutaBase = @"Archivos\";
        private const string ArchivoCitas = RutaBase + "citasmedicas.json";

        public CitaMedicaQuery()
        {
            citas = new List<CitaMedica>();
            VerificarCarpeta();
            CargarDatos();
        }

        private void VerificarCarpeta()
        {
            if (!Directory.Exists(RutaBase))
            {
                Directory.CreateDirectory(RutaBase);
            }
        }

        public List<CitaMedica> GetCitas()
        {
            return citas;
        }

        public CitaMedica GetCita(string id)
        {
            return citas.FirstOrDefault(c => c.Id == id);
        }

        public void AgregarCita(CitaMedica cita)
        {
            citas.Add(cita);
            GuardarCitas();
        }

        public void ActualizarCita(string id, CitaMedica cita)
        {
            foreach (var c in citas)
            {
                if (c.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(cita.IdPaciente)) c.IdPaciente = cita.IdPaciente;
                    if (!string.IsNullOrEmpty(cita.IdMedico)) c.IdMedico = cita.IdMedico;
                    if (cita.Fecha != null) c.Fecha = cita.Fecha;
                    if (!string.IsNullOrEmpty(cita.Hora)) c.Hora = cita.Hora;
                    if (!string.IsNullOrEmpty(cita.Especialidad)) c.Especialidad = cita.Especialidad;
                    if (!string.IsNullOrEmpty(cita.Estado)) c.Estado = cita.Estado;
                    GuardarCitas();
                    break;
                }
            }
        }

        public void InactivarCita(string id)
        {
            var c = citas.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                citas.Remove(c);
                GuardarCitas();
            }
        }

        private void GuardarCitas()
        {
            string jsonString = JsonSerializer.Serialize(citas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoCitas, jsonString);
        }

        private void CargarDatos()
        {
            if (File.Exists(ArchivoCitas))
            {
                string jsonString = File.ReadAllText(ArchivoCitas);
                citas = JsonSerializer.Deserialize<List<CitaMedica>>(jsonString) ?? new List<CitaMedica>();
            }
        }
    }
}
