using System.ComponentModel.DataAnnotations;

namespace CRUDFuncional.Models
{
    public class EmpleadosModel
    {
        public int IdEmpleado { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? NombreEmpleado { get; set; }
        
        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string? Cargo { get; set; }
    }
}
