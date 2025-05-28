using EstacionamientoMVC.C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstacionamientoMVC.C.Data
{
    public class MiDb_C : IdentityDbContext<IdentityUser<int>,IdentityRole<int>, int>
    {
        public MiDb_C(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Muchos a Muchos
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});

            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Cliente).WithMany(clt => clt.ClienteVehiculos);
            modelBuilder.Entity<ClienteVehiculo>().HasOne(cv => cv.Vehiculo).WithMany(veh => veh.ClientesAutorizados);

            #endregion

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            modelBuilder.Entity<Estancia>().Property(e => e.Monto).HasColumnType("decimal(18,2)");

        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<EstacionamientoMVC.C.Models.Empleado> Empleados { get; set; }
        public DbSet<EstacionamientoMVC.C.Models.ClienteVehiculo> ClienteVehiculos { get; set; }

        public DbSet<Rol> MisRoles { get; set; }


    }
}
