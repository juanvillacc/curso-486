using System.ComponentModel;

namespace Nevus.Models
{
    public class Ciudad
    {
        [DisplayName("Codigo")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}