using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Helpers
{
    public static class Contables
    {
        private static readonly decimal _valorHora = 100.00m;

        public static decimal ValorHora { get { return _valorHora; } }
        public static decimal CalcularMonto(DateTime Inicio,DateTime Fin)
        {
            decimal monto = 0;
            if (DateTime.Compare(Inicio, Fin) < 0)
            {
                TimeSpan tiempoEstancia = Fin - Inicio;

                monto = (decimal)tiempoEstancia.TotalHours * _valorHora;
            }
            return monto;
        }
    }
}
