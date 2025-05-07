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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Muchos a Muchos
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});

            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Cliente).WithMany(clt => clt.ClientesVehiculos);
            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Vehiculo).WithMany(veh => veh.ClientesVehiculos);

            #endregion
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }




    }
}
