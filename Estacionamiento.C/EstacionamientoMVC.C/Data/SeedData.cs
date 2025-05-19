// Data/SeedData.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EstacionamientoMVC.C.Models;
using EstacionamientoMVC.C.Helpers;

namespace EstacionamientoMVC.C.Data 
{
    public static class SeedData
    {
        public static void Initialize(MiDb_C context)
        {
            // Asegurarse de que la base de datos esté creada.
            // Para bases de datos en memoria, esto es menos crítico, pero bueno para otros proveedores si, y de hecho, migrate sería muy importante.
            //context.Database.EnsureCreated();

            if (context.Clientes.Any())
            {
                return;   // La BD ya ha sido poblada
            }

       
            // Clientes
            var cliente1 = new Cliente { Nombre = "Homero"  , Apellido = "Simpson"  , Email = "homero@ort.edu.ar"       , DNI = 22333444, CodigoIdentificacion = "20-22333444-0" };
            var cliente2 = new Cliente { Nombre = "Marge"   , Apellido = "Simpson"  , Email = "marge@ort.edu.ar"        , DNI = 11333555, CodigoIdentificacion = "20-11333555-0" };
            var cliente3 = new Cliente { Nombre = "Ned"     , Apellido = "Flanders" , Email = "ned@ort.edu.ar"          , DNI = 55444333, CodigoIdentificacion = "20-55444333-0" };
            var cliente4 = new Cliente { Nombre = "Apu"     , Apellido = "Nahasapeemapetilon", Email = "apu@ort.edu.ar" , DNI = 66555444, CodigoIdentificacion = "20-66555444-0" };
            var cliente5 = new Cliente { Nombre = "Barney"  , Apellido = "Perez"    , Email = "barney@ort.edu.ar"       , DNI = 77666555, CodigoIdentificacion = "20-77666555-0" }; 
            var cliente6 = new Cliente { Nombre = "Ana"     , Apellido = "Gomez"    , Email = "ana.perez@ort.edu.ar"    , DNI = 22333444, CodigoIdentificacion = "20-22333444-0" };
            var cliente7 = new Cliente { Nombre = "Luis     ", Apellido = "Perez"   , Email = "luis.perez@ort.edu.ar"   , DNI = 22333444, CodigoIdentificacion = "20-22333444-0" };
            context.Clientes.AddRange(cliente1, cliente2, cliente3, cliente4, cliente5, cliente6, cliente7);
            context.SaveChanges();

            // Empleados
            var fechafake = Generadores.ObtenerFechaRandom();

            var emp1 = new Empleado { Nombre = "Carlos", Apellido = "Rodriguez", DNI= 22333444, CodigoIdentificacion = "20-22333444-0", Email ="carlos@ort.edu.ar", CodigoEmpleado = Generadores.GetNewCodigoEmpleado(10), Fecha = fechafake };

            fechafake = Generadores.ObtenerFechaRandom();

            var emp2 = new Empleado { Nombre = "Laura", Apellido = "Gomez",DNI = 33444555, CodigoIdentificacion = "20-33444555-0", Email = "laura@ort.edu.ar", CodigoEmpleado = Generadores.GetNewCodigoEmpleado(10), Fecha = fechafake };
            var emp3 = new Empleado { Nombre = "Pedro", Apellido = "Martinez", DNI= 44555666, CodigoIdentificacion = "20-44555666-0", Email = "pedro@ort.edu.ar", CodigoEmpleado = Generadores.GetNewCodigoEmpleado(10),Fecha = fechafake };            

            context.Empleados.AddRange(emp1, emp2, emp3);
            context.SaveChanges();


            // Direcciones
            var dir1 = new Direccion { Calle = "Calle Falsa", Numero = 123, Piso = 3, Departamento = "A", CodigoPostal = "S1234QWR" ,ClienteId = cliente1.Id};
            var dir2 = new Direccion { Calle = "Avenida Siempreviva", Numero = 742, Piso = 2, Departamento = "B", CodigoPostal = "S33454ART", ClienteId = cliente2.Id };
            var dir3 = new Direccion { Calle = "Boulevard de los Sueños Rotos", Numero = 32, Piso = 10, Departamento = "C", CodigoPostal = "S33454ART" , ClienteId = cliente5.Id};
            var dir4 = new Direccion { Calle = "Plaza Mayor", Numero = 1852, Piso = 8, Departamento = "D", CodigoPostal = "C789AER",ClienteId=cliente3.Id};
            context.Direcciones.AddRange(dir1, dir2, dir3, dir4);
            context.SaveChanges();




            // Telefonos
            context.Telefonos.AddRange(
                new Telefono { Numero = 55331234, Tipo = TipoTelefono.Personal, ClienteId = cliente1.Id },
                new Telefono { Numero = 1523450954, Tipo = TipoTelefono.Celular, ClienteId = cliente1.Id },
                new Telefono { Numero = 55324765, Tipo = TipoTelefono.Personal, ClienteId = cliente2.Id }                
            );
            context.SaveChanges();

            // Vehiculos
            var vehiculo1 = new Vehiculo { Marca = "Ford", Color = "Negro", AnioFabricacion = 1980, Patente = "AAA111"};
            var vehiculo2 = new Vehiculo { Marca = "Chevrolet", Color = "Rojo", AnioFabricacion = 1975, Patente = "BBB222" };
            var vehiculo3 = new Vehiculo { Marca = "Toyota", Color = "Negro", AnioFabricacion = 2022, Patente = "CCC333" };
            var vehiculo4 = new Vehiculo { Marca = "Volkswagen", Color = "Verde", AnioFabricacion = 2018, Patente = "DDD444" };
            var vehiculo5 = new Vehiculo { Marca = "Toyota", Color = "Amarillo", AnioFabricacion = 2020, Patente = "EEE555" };
            context.Vehiculos.AddRange(vehiculo1, vehiculo2, vehiculo3, vehiculo4, vehiculo5);
            context.SaveChanges();


            // ClienteVehiculos (Relación muchos a muchos)
            context.ClienteVehiculos.AddRange(
                new ClienteVehiculo { ClienteId = cliente1.Id, VehiculoId = vehiculo1.Id, ResponsablePrincipal = true,FechaAsignacion = Generadores.ObtenerFechaRandom()},
                new ClienteVehiculo { ClienteId = cliente1.Id, VehiculoId = vehiculo3.Id, ResponsablePrincipal = true, FechaAsignacion = Generadores.ObtenerFechaRandom() },
                new ClienteVehiculo { ClienteId = cliente2.Id, VehiculoId = vehiculo1.Id, ResponsablePrincipal = false, FechaAsignacion = Generadores.ObtenerFechaRandom() },
                new ClienteVehiculo { ClienteId = cliente6.Id, VehiculoId = vehiculo5.Id, ResponsablePrincipal = true, FechaAsignacion = Generadores.ObtenerFechaRandom() }
            );
            context.SaveChanges();
        }
    }
}