using EstacionamientoMVC.C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EstacionamientoMVC.C.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstacionamientoMVC.C.Controllers
{
    public class LinqExamplesController : Controller
    {
        private readonly MiDb_C _context;

        public LinqExamplesController(MiDb_C context)
        {
            _context = context;
        }

        // Página principal con enlaces a los ejemplos
        public IActionResult Index()
        {
            return View();
        }

        // 1. FindAsync: Encontrar una entidad por su clave primaria.
        public async Task<IActionResult> EjemploFind(int id = 1)
        {
            ViewBag.IdEjemplo = id;
            ViewBag.Descripcion = "Busca una entidad por su clave primaria (PK). Devuelve `null` si no la encuentra. Es eficiente para búsquedas por PK.";
            ViewBag.LinqExpresion = $"_context.Clientes.FindAsync({id})";
            var cliente = await _context.Clientes.FindAsync(id);
            return View("ResultadoCliente", cliente); // Vista genérica para mostrar un cliente
        }

        // 2. FirstOrDefaultAsync: Encontrar la primera entidad que cumpla una condición.
        public async Task<IActionResult> EjemploFirstOrDefault(string nombreBuscado = "Homero")
        {
            ViewBag.NombreBuscado = nombreBuscado;
            ViewBag.Descripcion = "Devuelve el primer elemento que satisface una condición, o `null` (o valor por defecto) si no se encuentra ninguno.";
            ViewBag.LinqExpresion = $"_context.Clientes.FirstOrDefaultAsync(c => c.Nombre == \"{nombreBuscado}\")";
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Nombre == nombreBuscado);
            return View("ResultadoCliente", cliente);
        }

        // 3. Where: Filtrar entidades por una condición.
        public async Task<IActionResult> EjemploWhere(string apellidoBuscado = "Simpson")
        {
            ViewBag.ApellidoBuscado = apellidoBuscado;
            ViewBag.Descripcion = "Filtra una secuencia de valores basada en un predicado (condición). Devuelve todos los elementos que cumplen.";
            ViewBag.LinqExpresion = $"_context.Clientes.Where(c => c.Apellido == \"{apellidoBuscado}\").ToListAsync()";
            var clientes = await _context.Clientes.Where(c => c.Apellido == apellidoBuscado).ToListAsync();
            return View("ResultadoListaClientes", clientes); // Vista genérica para listar clientes
        }

        // 4. OrderBy / OrderByDescending: Ordenar entidades.
        public async Task<IActionResult> EjemploOrderBy()
        {
            ViewBag.Descripcion = "Ordena los elementos de una secuencia. `OrderBy` es ascendente, `OrderByDescending` es descendente.";
            ViewBag.LinqExpresion = "_context.Empleados.OrderByDescending(e => e.FechaContratacion).ThenBy(e => e.Apellido).ToListAsync()";
            // Ordena por fecha de contratación (más nuevo primero), luego por apellido A-Z
            var empleados = await _context.Empleados
                                          .OrderByDescending(e => e.Fecha) //Ejemplo de orden primario
                                          .ThenBy(e => e.Apellido) // Ejemplo de orden secundario
                                          .ToListAsync();
            return View("ResultadoListaEmpleados", empleados);
        }

        // ViewModel para el resultado de GroupBy
        public class ClientesPorCodigoPostalViewModel
        {
            public string CodigoPostal { get; set; }
            public int CantidadClientes { get; set; }
            public List<Cliente> Clientes { get; set; }
        }

        // 5. GroupBy: Agrupar entidades.
        public async Task<IActionResult> EjemploGroupBy()
        {
            ViewBag.Descripcion = "Agrupa los elementos de una secuencia según una función selectora de clave. Es útil para resúmenes y agregaciones.";
            ViewBag.LinqExpresion = "_context.Clientes.Include(c => c.Direccion).Where(c => c.Direccion != null).GroupBy(c => c.Direccion.CodigoPostal) ...";
            var gruposClientes = await _context.Clientes
                                        .Include(c => c.Direccion) // Necesario para acceder a c.Direccion.CodigoPostal
                                        .Where(c => c.Direccion != null && c.Direccion.CodigoPostal != null) // Evitar nulls en la clave de agrupación
                                        .GroupBy(c => c.Direccion.CodigoPostal) // Agrupa por CodigoPostal
                                        .Select(g => new ClientesPorCodigoPostalViewModel
                                        {
                                            CodigoPostal = g.Key, // La clave del grupo (la CodigoPostal)
                                            CantidadClientes = g.Count(),
                                            Clientes = g.ToList() // Los clientes en ese grupo
                                        })
                                        .OrderBy(vm => vm.CodigoPostal)
                                        .ToListAsync();
            return View(gruposClientes);
        }

        // 6. Include: Cargar datos relacionados (Eager Loading).
        public async Task<IActionResult> EjemploInclude(int clienteId = 1)
        {
            ViewBag.IdEjemplo = clienteId;
            ViewBag.Descripcion = "`Include` permite especificar datos relacionados para ser incluidos en los resultados de la consulta (Eager Loading).";
            ViewBag.LinqExpresion = $"_context.Clientes.Include(c => c.Direccion).FirstOrDefaultAsync(c => c.Id == {clienteId})";
            
            var clienteConDireccion = await _context.Clientes
                                            .Include(c => c.Direccion) // Carga la Dirección del cliente
                                            .FirstOrDefaultAsync(c => c.Id == clienteId);
            
            return View("ResultadoClienteConDireccion", clienteConDireccion);
        }

        // 7. ThenInclude: Cargar datos relacionados de segundo nivel o más.
        public async Task<IActionResult> EjemploThenInclude(int clienteId = 1)
        {
            ViewBag.IdEjemplo = clienteId;
            ViewBag.Descripcion = "`ThenInclude` se usa para incluir niveles adicionales de datos relacionados después de un `Include`. Ejemplo: Cliente -> ClienteVehiculos -> Vehiculo.";
            ViewBag.LinqExpresion = $"_context.Clientes.Include(c => c.ClienteVehiculos).ThenInclude(cv => cv.Vehiculo).FirstOrDefaultAsync(c => c.Id == {clienteId})";

            var clienteConVehiculos = await _context.Clientes
                                          .Include(c => c.ClienteVehiculos) // Incluye la colección de entidades de unión (ClienteVehiculos)
                                              .ThenInclude(cv => cv.Vehiculo) // Para cada ClienteVehiculos, incluye el Vehiculo asociado
                                          .Include(c => c.Telefonos) // También incluimos los teléfonos directamente del cliente
                                          .FirstOrDefaultAsync(c => c.Id == clienteId);
                      
            return View("ResultadoClienteConVehiculosYTelefonos", clienteConVehiculos);
        }

        // Ejemplo adicional: Seleccionar datos específicos (Proyección) y múltiples Includes
        public async Task<IActionResult> EjemploProyeccionYMultiInclude(string marcaVehiculo = "Ford")
        {
            /*
                En el contexto de LINQ (Language Integrated Query), la proyección es el proceso de transformar los elementos de una secuenci(como los resultados de una consulta a la base de datos) en una nueva forma. Es decir, en lugar de obtener el objeto completo tal cual está en la base de datos (por ejemplo, un objeto Cliente con todas sus propiedades), puedes "proyectar" o seleccionar solo las partes que te interesan, o incluso crear un nuevo tipo de objeto con una estructura diferente a partir de los datos originales.
            */

            ViewBag.MarcaBuscada = marcaVehiculo;
            ViewBag.Descripcion = "Seleccionar datos específicos (proyección a un ViewModel o tipo anónimo) y usar múltiples `Include` para cargar las relaciones necesarias de forma eficiente.";
            ViewBag.LinqExpresion = "_context.Vehiculos.Where(v => v.Marca == ...).Include(v => v.ClienteVehiculos).ThenInclude(cv => cv.Cliente).ThenInclude(cli => cli.Direccion).Select(...)";

            var resultado = await _context.Vehiculos
                .Where(v => v.Marca == marcaVehiculo)
                .Include(v => v.ClientesAutorizados) // Vehiculo -> ClienteVehiculos
                    .ThenInclude(cv => cv.Cliente) // ClienteVehiculos -> Cliente
                        .ThenInclude(cli => cli.Direccion) // Cliente -> Direccion
                .Select(v => new VehiculoConPropietariosViewModel
                {
                    MarcaColorVehiculo = $"{v.Marca} {v.Color} ({v.AnioFabricacion})",
                    Patente = v.Patente,
                    Propietarios = v.ClientesAutorizados.Select(cv => 
                                            new PropietarioInfoViewModel
                                            {
                                                NombreCompleto = $"{cv.Cliente.Nombre} {cv.Cliente.Apellido}",
                                                Email = cv.Cliente.Email,
                                                CodigoPostalCliente = cv.Cliente.Direccion != null ? cv.Cliente.Direccion.CodigoPostal : "N/A",
                                                FechaAsignacion = cv.FechaAsignacion
                                            }
                                            ).ToList()
                }
                )
                .ToListAsync();

            return View(resultado);
        }
    }

    // ViewModels para el ejemplo de Proyección
    public class VehiculoConPropietariosViewModel
    {
        public string MarcaColorVehiculo { get; set; }
        public string Patente { get; set; }
        public List<PropietarioInfoViewModel> Propietarios { get; set; }
    }

    public class PropietarioInfoViewModel
    {
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string CodigoPostalCliente { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
