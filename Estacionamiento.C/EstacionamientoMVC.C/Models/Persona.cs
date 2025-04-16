using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50,MinimumLength = 2,ErrorMessage = "Debe estar entre {2} y {1}")]
        public string Nombre { get; set; } = "Sin definir";


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(60, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [MinLength(2,ErrorMessage = "El campo {0} debe superar los {1} caracteres")]
        public string Apellido { get; set; }


        [Range(1, 99999999, ErrorMessage = "{0} Debe estar entre {1} y {2}")]
        [Display(Name = "Documento")]
        public int DNI { get; set; }

        
        public string CodigoIdentificacion { get; set; } 

        public bool Activo { get; set; } = true;

        //Prop Navegacional
        public Direccion Direccion { get; set; }


        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
