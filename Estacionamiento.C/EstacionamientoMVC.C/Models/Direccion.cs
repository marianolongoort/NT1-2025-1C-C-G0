﻿using EstacionamientoMVC.C.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.C.Models
{
    public class Direccion
    {
        [Display(Name = Alias.ClienteId)]
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(50)]
        public string Calle { get; set; }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Numero { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Piso { get; set; } = 0;


        public string Departamento { get; set; } = "N/A";

        [RegularExpression(@"^[a-zA-Z]{1}[0-9]{4}[a-zA-Z]{3}$", ErrorMessage = ErrMsgs.CodPostal)]
        public string CodigoPostal { get; set; } = "N/A";

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int ClienteId { get; set; }


        public string DireccionCompleta { get { 
                return $"{Calle} {Numero} {Piso}{Departamento}, ({CodigoPostal})"; 
            }  }
    }
}