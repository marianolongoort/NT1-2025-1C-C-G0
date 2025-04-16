using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }
    }
}
