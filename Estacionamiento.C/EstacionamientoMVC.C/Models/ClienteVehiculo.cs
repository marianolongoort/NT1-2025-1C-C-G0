
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.C.Models
{
    public class ClienteVehiculo
    {
        //Prop Relacionales
        [Key,Column("1")]
        public int ClienteId { get; set; }

        [Key,Column("2")]
        public int VehiculoId { get; set; }

        //Prop Navegacionales
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
