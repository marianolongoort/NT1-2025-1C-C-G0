using EstacionamientoMVC.C.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstacionamientoMVC.C.Data
{
    public class MiDb_C : DbContext
    {
        public MiDb_C(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }




    }
}
