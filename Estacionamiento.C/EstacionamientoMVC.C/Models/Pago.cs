using EstacionamientoMVC.C.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.C.Models
{
    public class Pago
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name =Alias.EstanciaId)]
        public int EstanciaId { get; set; }
        public Estancia Estancia { get; set; }

        [NotMapped]
        public decimal Monto
        {
            get { 
                if(Estancia != null)
                    return Estancia.Monto;
                return 0;
            }
        }

   }
}