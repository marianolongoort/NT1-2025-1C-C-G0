using EstacionamientoMVC.C.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Login
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool Recordarme { get; set; } = false;

    }
}
