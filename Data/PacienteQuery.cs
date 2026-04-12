using Proyecto_Melvin_Gerald_Clinica.Models;
using System.Text.Json;

namespace Proyecto_Melvin_Gerald_Clinica.Data
{
    public class PacienteQuery
    {
        private List<Paciente> pacientes;
        private const string RutaBase = @"Archivos\";
        private const string ArchivoPacientes = RutaBase + "pacientes.json";

        public PacienteQuery()
        {
            pacientes = new List<Paciente>();
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

        public List<Paciente> GetPacientes()
        {
            return pacientes;
        }

        public Paciente GetPaciente(string id)
        {
            return pacientes.FirstOrDefault(p => p.Id == id);
        }

        public Paciente BuscarPacientePorCedula(string cedula)
        {
            return pacientes.FirstOrDefault(p => p.Cedula == cedula);
        }

        public void AgregarPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
            GuardarPacientes();
        }

        public void ActualizarPaciente(string id, Paciente paciente)
        {
            foreach (var p in pacientes)
            {
                if (p.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(paciente.Nombre)) p.Nombre = paciente.Nombre;
                    if (!string.IsNullOrEmpty(paciente.Cedula)) p.Cedula = paciente.Cedula;
                    if (paciente.FechaNacimiento != null) p.FechaNacimiento = paciente.FechaNacimiento;
                    if (!string.IsNullOrEmpty(paciente.Genero)) p.Genero = paciente.Genero;
                    if (!string.IsNullOrEmpty(paciente.Direccion)) p.Direccion = paciente.Direccion;
                    if (!string.IsNullOrEmpty(paciente.Telefono)) p.Telefono = paciente.Telefono;
                    if (!string.IsNullOrEmpty(paciente.Correo)) p.Correo = paciente.Correo;
                    if (!string.IsNullOrEmpty(paciente.EstadoClinico)) p.EstadoClinico = paciente.EstadoClinico;
                    GuardarPacientes();
                    break;
                }
            }
        }

        public void InactivarPaciente(string id)
        {
            var p = pacientes.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                pacientes.Remove(p);
                GuardarPacientes();
            }
        }

        private void GuardarPacientes()
        {
            string jsonString = JsonSerializer.Serialize(pacientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoPacientes, jsonString);
        }

        private void CargarDatos()
        {
            if (File.Exists(ArchivoPacientes))
            {
                string jsonString = File.ReadAllText(ArchivoPacientes);
                pacientes = JsonSerializer.Deserialize<List<Paciente>>(jsonString) ?? new List<Paciente>();
            }
        }
    }
}
