using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Helpers
{
    public static class Configs
    {
        public const int CantClientes = 10;
        public const string StrNotDef = "N/D";
        public const string FotoDef = "default.png";
        public const string VehiculoDef = "default_car.png";
        public const string FotoURL = "~/img/fotos/";
        public const string FotoPATH = "img\\fotos";
        public const string VehiculosURL = "~/img/Vehiculos/";
        public const string VehiculosPATH = "img\\Vehiculos";
        public const string LoginPath = "/Account/IniciarSesion";
        public const string AccessDeniedPath = "/Account/AccesoDenegado";
        public const string CoockieName = "GarageIncCookie";
        public const string Titulo = "Garage Inc.";
        public const string AdminEmail = "admin@ort.edu.ar";
        public const string AdminPass = "Password1!";
        public const string Dominio = "@ort.edu.ar";
        public const string CltEmail = "cliente";
        public const string EmpEmail = "empleado";
        public const string DefaultPass = "Password1!";
        public const string AdminRolName = "Administrador";
        public const string EmpleadoRolName = "Empleado";
        public const string AuthEmpOrAdm = "Empleado,Administrador";
        public const string AuthCltOrEmpOrAdm = "Cliente,Empleado,Administrador";
        public const string ClienteRolName = "Cliente";
        public const string UsuarioRolName = "Usuario";
        public const int MaxEdadVehiculo = 30;
        public const string NotDefined = "N/D";
        public static int MinAnioVehiculo { get {return DateTime.Now.Year - MaxEdadVehiculo;} }    
        public static int MaxAnioVehiculo = DateTime.Now.Year;
        public const string NombreBase = "Clt";
        public const int DNI = 11222333;
        private readonly static string CuitPrefix = "20";
        private readonly static string CuitSufix = "0";
        private readonly static string CuitConcatenado = string.Concat(CuitPrefix,DNI.ToString(),CuitSufix);
        public static long CuitBase = long.Parse(CuitConcatenado);
        public static readonly List<string> RolesParaEmpleado = new List<string>() { EmpleadoRolName, UsuarioRolName };
        public static readonly List<string> RolesParaCliente = new List<string>() { ClienteRolName, UsuarioRolName };
        public static readonly List<string> RolesParaAdmin = new List<string>() { AdminRolName, UsuarioRolName };
        public static readonly List<string> RolesBase = new List<string>() { AdminRolName, EmpleadoRolName, ClienteRolName, UsuarioRolName };
        public static readonly List<string> VehiculosMarcas = new List<string>()    { "Ford",       "Chevrolet",    "Fiat",         "Citroen",          "Renault",      "Peugeot",  "Ferrari",  "Porsche","Torino","Delorean"};
        public static readonly List<string> Colores = new List<string>()            { "#17562f",    "#f00d3d",      "#1ec2c0",      "#456535",          "#f69001",      "#ffffff",  "#fc1805", "#eaf00d" , "#150af2", "#b7b7bd" };
        public static readonly List<string> FotosVehiculos = new List<string>()     { "Falcon.jpg", "Chevy.jfif",   "Fitito.jpg",   "Citroneta.jpg",    "Renoleta.jpg", "404.jpg",  "Ferrari.jpg","Porsche.jpg","Torino.jpg","Delorean.jpg"};
        public static readonly List<string> FotosClientes = new List<string>() {"Rick.jpg","LaCajaVengadora.png","Ironman.jfif","Natasha.jpg","Capitan.jpeg","MrIncreible.jpg","Vilma.jpg","Betty.jpg","Batman.jpg","Spiderman.jpg" };

    }
}
