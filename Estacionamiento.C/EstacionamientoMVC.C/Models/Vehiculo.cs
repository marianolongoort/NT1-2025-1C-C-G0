using EstacionamientoMVC.C.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Models
{
    public class Vehiculo
    {
        private string patente;

        [Display(Name = Alias.VehiculoId)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Patente { get {return patente.ToUpper(); } set { patente = value.ToUpper(); } }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Marca { get; set; }
                
        [Required(ErrorMessage = ErrMsgs.Requerido)]        
        public string Color { get; set; } 

        
        [Range(Restrictiones.FloorVehiculoAnio, Restrictiones.CeilVehiculoAnio, ErrorMessage = ErrMsgs.RangoMinMax)]
        [Display(Name = Alias.Anio)]
        public int AnioFabricacion { get; set; } = DateTime.Now.Year;

        public List<ClienteVehiculo> ClientesAutorizados { get; set; }

        public List<Estancia> Estancias { get; set; }

        public string Foto { get; set; } = Configs.VehiculoDef;
    }
}
