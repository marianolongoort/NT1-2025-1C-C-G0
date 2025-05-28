using EstacionamientoMVC.C.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Registrar
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string UserName { get; set; }
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [EmailAddress(ErrorMessage ="Debe ser una dirección de correo válida")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="La pass no es igual.")]
        public string ConfirmPassword { get; set; }


    }
}
