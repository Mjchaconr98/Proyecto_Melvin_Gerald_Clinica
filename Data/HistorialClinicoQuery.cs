using Proyecto_Melvin_Gerald_Clinica.Models;
using System.Text.Json;

namespace Proyecto_Melvin_Gerald_Clinica.Data
{
    public class HistorialClinicoQuery
    {
        private List<HistorialClinico> historiales;
        private const string RutaBase = @"Archivos\";
        private const string ArchivoHistoriales = RutaBase + "historialesclinicos.json";

        public HistorialClinicoQuery()
        {
            historiales = new List<HistorialClinico>();
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

        public List<HistorialClinico> GetHistoriales()
        {
            return historiales;
        }

        public HistorialClinico GetHistorial(string id)
        {
            return historiales.FirstOrDefault(h => h.Id == id);
        }

        public void AgregarHistorial(HistorialClinico historial)
        {
            historiales.Add(historial);
            GuardarHistoriales();
        }

        public void ActualizarHistorial(string id, HistorialClinico historial)
        {
            foreach (var h in historiales)
            {
                if (h.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(historial.IdPaciente)) h.IdPaciente = historial.IdPaciente;
                    if (!string.IsNullOrEmpty(historial.IdMedico)) h.IdMedico = historial.IdMedico;
                    if (!string.IsNullOrEmpty(historial.Diagnostico)) h.Diagnostico = historial.Diagnostico;
                    if (!string.IsNullOrEmpty(historial.Tratamiento)) h.Tratamiento = historial.Tratamiento;
                    if (historial.FechaConsulta != null) h.FechaConsulta = historial.FechaConsulta;
                    GuardarHistoriales();
                    break;
                }
            }
        }

        // Delete no se implementa porque así fueron especificados los historiales médicos.

        private void GuardarHistoriales()
        {
            string jsonString = JsonSerializer.Serialize(historiales, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoHistoriales, jsonString);
        }

        private void CargarDatos()
        {
            if (File.Exists(ArchivoHistoriales))
            {
                string jsonString = File.ReadAllText(ArchivoHistoriales);
                historiales = JsonSerializer.Deserialize<List<HistorialClinico>>(jsonString) ?? new List<HistorialClinico>();
            }
        }
    }
}
