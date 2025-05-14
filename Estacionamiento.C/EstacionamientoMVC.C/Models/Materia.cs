using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PNT1PORTAL.ORT.EDU.AR.Models
{
    //Fines ilustrativos e introductorios para la materia.
    public class Materia
    {
        public string Name { get; set; } = "Programación en nuevas tecnologías 1";
        public string Alias { get; set; } = "PNT1";
        public Docente  Docente { get; set; } = new Docente(
                                                        "Mariano",
                                                        "Longo",
                                                        "mariano.longo@ort.edu.ar"
                                                );
        public List<Grupo> Grupos { get; set; } = [];
    }

    public class Grupo
    {

        public int Id { get; set; }



        [Range(1,10)]
        public int Numero { get; set; }

        [RegularExpression(@"^[A-Z]{1}$")]
        public string Curso { get; set; }

        [AllowedValues("A","B")]
        public string CursoLetra { get; set; }

        public TipoProyecto Proyecto { get; set; }
        
        [Length(3, 5)]
        public List<Alumno> Alumnos { get; set; } //Se permite solo 3 y 5 por matemáticas
        /*
            - Trabajos individuales (solo casos excepcionales autorizados por el docente)
            - No al libro de pases por afinidad o deseo
            - Tareas, asignación y organización definida por miembros del grupo
            - Manejo de problemas interno del grupo, pero levanten la mano si es requerido
            - Compromiso individual, no solo por lo personal, sino compromiso con el grupo
         */
    }

    public class Alumno{}


    public enum TipoProyecto
    {
        [Display(Name ="Agenda Turnos")] Agenda, 
        [Display(Name = "Carrito de compras")] Carrito, 
        [Display(Name = "Reserva de espectaculo")] Reserva, 
        [Display(Name = "Wiki")] Wiki, 
        [Display(Name = "Historias Clínicas")] Historias,
        [Display(Name = "Instituto educativo")] Instituto, 
        [Display(Name = "ERP Básico")] ERP,
        [Display(Name = "Foro")] Foro,
        [Display(Name = "Licencias médicas")] Licencias
    }

    public class Docente
    {
        public Docente(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        [Required][MinLength(2)][MaxLength(50)]
        public string Nombre { get; set; }

        [Required][StringLength(50,MinimumLength =2)]
        public string Apellido { get; set; }
        
        [Required][EmailAddress]
        public string Email { get; set; }
    }
}
