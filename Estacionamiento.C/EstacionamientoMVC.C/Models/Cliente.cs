using System.Collections.Generic;

namespace EstacionamientoMVC.C.Models
{
    public class Cliente : Persona
    {
        public List<Telefono> Telefonos { get; set; }
        
        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

       
    }
}
