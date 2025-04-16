using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        //prop navegacional

        public Persona Persona { get; set; }
         //Prop Relacional
        [Required]
        public int PersonaId { get; set; }
    }
}
