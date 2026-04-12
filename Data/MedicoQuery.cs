using Proyecto_Melvin_Gerald_Clinica.Models;
using System.Text.Json;

namespace Proyecto_Melvin_Gerald_Clinica.Data
{
    public class MedicoQuery
    {
        private List<Medico> medicos;
        private const string RutaBase = @"Archivos\";
        private const string ArchivoMedicos = RutaBase + "medicos.json";

        public MedicoQuery()
        {
            medicos = new List<Medico>();
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

        public List<Medico> GetMedicos()
        {
            return medicos;
        }

        public Medico GetMedico(string id)
        {
            return medicos.FirstOrDefault(m => m.Id == id);
        }

        public void AgregarMedico(Medico medico)
        {
            medicos.Add(medico);
            GuardarMedicos();
        }

        public void ActualizarMedico(string id, Medico medico)
        {
            foreach (var m in medicos)
            {
                if (m.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(medico.Nombre)) m.Nombre = medico.Nombre;
                    if (!string.IsNullOrEmpty(medico.CedulaProfesional)) m.CedulaProfesional = medico.CedulaProfesional;
                    if (!string.IsNullOrEmpty(medico.Especialidad)) m.Especialidad = medico.Especialidad;
                    if (!string.IsNullOrEmpty(medico.Telefono)) m.Telefono = medico.Telefono;
                    if (!string.IsNullOrEmpty(medico.Correo)) m.Correo = medico.Correo;
                    if (!string.IsNullOrEmpty(medico.HorarioConsulta)) m.HorarioConsulta = medico.HorarioConsulta;
                    if (!string.IsNullOrEmpty(medico.Estado)) m.Estado = medico.Estado;
                    GuardarMedicos();
                    break;
                }
            }
        }

        public void InactivarMedico(string id)
        {
            var m = medicos.FirstOrDefault(x => x.Id == id);
            if (m != null)
            {
                medicos.Remove(m);
                GuardarMedicos();
            }
        }

        private void GuardarMedicos()
        {
            string jsonString = JsonSerializer.Serialize(medicos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoMedicos, jsonString);
        }

        private void CargarDatos()
        {
            if (File.Exists(ArchivoMedicos))
            {
                string jsonString = File.ReadAllText(ArchivoMedicos);
                medicos = JsonSerializer.Deserialize<List<Medico>>(jsonString) ?? new List<Medico>();
            }
        }
    }
}
