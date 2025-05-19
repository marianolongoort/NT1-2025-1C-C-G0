using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Helpers
{
    public static class Generadores
    {
        private static Random random = new Random();
        private static string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string numeros = "0123456789";

        public static string GetNewCodigoEmpleado(int largo)
        {
            var resu = GetRand(caracteres, largo);
            return resu;
        }

        private static string GetRand(string caracteres,int largo)
        {
            return new string(Enumerable.Repeat(caracteres, largo).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetNewPatente()
        {
            return GetRand(letras, 3) + GetRand(numeros, 3);
        }

        public static int GetAnio()
        {
            return random.Next(Configs.MinAnioVehiculo,Configs.MaxAnioVehiculo);
        }

        public static DateTime ObtenerFechaRandom()
        {
            Random random = new Random();
            int dias = random.Next(0, 3650); // 10 años * 365 días
            return DateTime.Today.AddDays(-dias);
        }
    }


}
