using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Entities
{
    public class EmployeeVO
    {

        public EmployeeVO()
        {
            Fotografia = "";
            APaterno = "";
            Email = "";
            Nombre = "";
            PuestoId = 0;
            FechaNacimiento = "";
            Direccion = "";
            EstadoId = 0;
            FechaContratacion = "";
            Telefono = "";
            Puesto = "";
            Estado = "";
        }

        public int Id { get; set; }
        public string Fotografia { get; set; }
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
    }
}
