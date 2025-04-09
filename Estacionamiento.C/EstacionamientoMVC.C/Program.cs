using EstacionamientoMVC.C.Models;

namespace EstacionamientoMVC.C
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


            

            string nombre = "Pedro";
            string apellido = "Picapiedra";

            Persona persona1 = new Persona() { 
                Nombre = nombre,
                Apellido = apellido,
                CodUnico = 22
            };
            
            
            persona1.Nombre = nombre;
            persona1.Apellido = apellido;
            

            string otroNombre = persona1.Nombre;
            
            Console.WriteLine(persona1.Apellido);

        }
    }
}
