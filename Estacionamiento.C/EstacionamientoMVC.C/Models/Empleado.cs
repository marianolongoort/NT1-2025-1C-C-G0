using EstacionamientoMVC.C.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Models
{
    public class Empleado : Persona
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictiones.CeilL1, MinimumLength = Restrictiones.FloorL4, ErrorMessage = ErrMsgs.FixedSize)]
        public string CodigoEmpleado { get; set; } = Generadores.GetNewCodigoEmpleado(Restrictiones.CeilL1);


    }
}
