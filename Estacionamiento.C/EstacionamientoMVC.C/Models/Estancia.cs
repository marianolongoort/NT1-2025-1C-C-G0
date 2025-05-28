using EstacionamientoMVC.C.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Models
{
    public class Estancia
    {     
        public int Id { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = Alias.VehiculoId)]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = Alias.ClienteId)]
        public int ClienteId{ get; set; }



        public Cliente Cliente { get; set; }
        
        //[Precision(18,2)]
        public decimal Monto { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime Inicio { get; set; } = DateTime.Now;

        
        private DateTime? fin = null;

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime? Fin
        {
            get { return fin; }
            set
            {
                fin = value;
                Monto = Contables.CalcularMonto(Inicio, Fin.Value);
            }
        }

        public string Detalle { get {                
                return ConstruirDetalle();            
            } }

        private string ConstruirDetalle()
        {
            string detalle = string.Empty;
            string separador = " - ";

            if (Vehiculo != null && Fin != null)
            {
                detalle += Vehiculo.Patente + separador;
                detalle += Fin.Value.ToString("yyyy.MM.dd_HH.mm") + separador;
                detalle += Alias.Moneda + Monto;
            }
            return detalle;
        }


        public Pago Pago { get; set; }
    }
}
