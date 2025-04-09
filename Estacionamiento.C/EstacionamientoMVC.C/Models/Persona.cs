namespace EstacionamientoMVC.C.Models
{
    public class Persona
    {
        private string apellido;

        public string Nombre { get; set; } = "Sin definir";

        public string Apellido {
            get { return apellido.ToUpper(); }
            set { apellido = value; }
        }

        public int CodUnico { get; set; } = -44;



        public bool Activo { get; set; } = true;

    }
}
