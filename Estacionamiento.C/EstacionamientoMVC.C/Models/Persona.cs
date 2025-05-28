using EstacionamientoMVC.C.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class Persona : IdentityUser<int>
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictiones.CeilL3, MinimumLength = Restrictiones.FloorL1, ErrorMessage = ErrMsgs.StrMaxMin)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [MaxLength(Restrictiones.CeilL3, ErrorMessage = ErrMsgs.StrMax)]
        public string Apellido { get; set; }


        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public override string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public string NombreCompleto
        {
            get
            {
                return string.IsNullOrWhiteSpace(Apellido) && string.IsNullOrWhiteSpace(Nombre) ? Configs.NotDefined :
                       !string.IsNullOrWhiteSpace(Apellido) && !string.IsNullOrWhiteSpace(Nombre) ? $"{Apellido}, {Nombre}" :
                       !string.IsNullOrWhiteSpace(Apellido) ? Apellido : Nombre;
            }
        }

        public string Foto { get; set; } = Configs.FotoDef;


        [Range(1, 99999999, ErrorMessage = "{0} Debe estar entre {1} y {2}")]
        [Display(Name = "Documento")]
        public int DNI { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = AliasGUI.CuilCuit)]
        [RegularExpression(@"^(20|23|24|27|30|33|34)-\d{7,8}-\d$", ErrorMessage = "El CUIT/CUIL no es válido.")]
        public string CodigoIdentificacion { get; set; }

        //Prop Navegacional
        public Direccion Direccion { get; set; }
        public bool Activo { get; set; } = true;

        public virtual DateTime Fecha { get; set; }  = DateTime.Now;
    }
}
