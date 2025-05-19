using EstacionamientoMVC.C.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public class ClienteVehiculo
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Key]                
        [Display(Name = Alias.ClienteId)]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Key]        
        [Display(Name = Alias.VehiculoId)]
        public int VehiculoId { get; set; }

        [Display(Name = Alias.ClienteId)]
        public Cliente Cliente { get; set; }

        [Display(Name = Alias.VehiculoId)]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name =Alias.ResponsablePrincipal)]
        public bool ResponsablePrincipal { get; set; }

        public DateTime FechaAsignacion  { get; set; } = DateTime.Now;
    }
}