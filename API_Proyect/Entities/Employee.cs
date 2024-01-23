using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace API_Proyect.Entities
{
    [DataContract]
    public class EmployeeVO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public int PuestoId { get; set; }
        public string Puesto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaContratacion { get; set; }
        public string Fotografia { get; set; }
    }
}
