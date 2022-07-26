using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nevus.Models
{
    public class Departamento
    {
        [Required(ErrorMessage = "Debe llenar el codigo")]
        [DisplayName("Codigo")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe llenar el departamento")]
        public string Nombre { get; set; }
        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}