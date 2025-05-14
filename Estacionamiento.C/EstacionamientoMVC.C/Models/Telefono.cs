using EstacionamientoMVC.C.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]        
        public CodigoDeArea CodArea { get; set; }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Range(Restrictiones.FloorTelNum, Restrictiones.CeilTelNum)]
        public int Numero { get; set; }

        [Display(Name = Alias.NumeroCompleto)]
        public string NumeroCompleto { 
            get {
                
                return $"{Misc.GetEnumDisplayName(CodArea)}-{Numero}"; 
            }
        }

        public bool Principal { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public TipoTelefono Tipo { get; set; }

        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = Alias.ClienteId)]
        public int ClienteId { get; set; } 

        public Cliente Cliente{ get; set; }
    }
}
