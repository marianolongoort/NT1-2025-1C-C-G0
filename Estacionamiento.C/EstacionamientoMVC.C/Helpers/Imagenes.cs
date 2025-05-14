using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Helpers
{
    public static class Imagenes
    {

        //Sube una imagen, y devuelve el nombre único definido.
        public static string Subir(string rutaRaiz,string rutaTipo, string usuario, IFormFile archivo)
        {
            string nombreArchivoUnico = null;
            if (!string.IsNullOrEmpty(rutaRaiz) && !string.IsNullOrEmpty(rutaTipo) && archivo != null)
            {
                string carpeta = Path.Combine(rutaRaiz, rutaTipo);
                
                nombreArchivoUnico = Guid.NewGuid().ToString() + (!string.IsNullOrEmpty(usuario) ? "_" + usuario : "_" + "Sistema") + "_" + archivo.FileName;

                string carpetaArchivo = Path.Combine(carpeta, nombreArchivoUnico);

                archivo.CopyTo(new FileStream(carpetaArchivo, FileMode.Create));

            }
            return nombreArchivoUnico;
        }


        public static string GetPath(string filename)
        {
            return Misc.GetUrlPath(Configs.FotoURL, filename, Configs.FotoDef);            
        }
    }
}
