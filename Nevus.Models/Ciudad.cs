using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nevus.Models
{
    public class Ciudad
    {
        [Key]
        [Required(ErrorMessage = "Debe llenar el codigo")]
        [DisplayName("Codigo")]
        public Int64 Id { get; set; }
        [Required(ErrorMessage = "Debe llenar la ciudad")]
        [NoNumbersValidator(ErrorMessage = "La ciudad solo debe contener letras")]
        [DataType(DataType.MultilineText)]
        public string Nombre { get; set; }
        [DisplayName("Esta activa la ciudad?")]
        public bool EstaActiva { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}