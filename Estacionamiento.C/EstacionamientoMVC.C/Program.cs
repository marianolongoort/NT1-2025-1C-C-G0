using EstacionamientoMVC.C.Data;
using EstacionamientoMVC.C.Helpers;
using EstacionamientoMVC.C.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace EstacionamientoMVC.C
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string cs = builder.Configuration.GetConnectionString("EstacionamientoCS");

            #region Ejemplo exclusivo para alumnos con MAC que usan un container

            string hostname = Environment.GetEnvironmentVariable("COMPUTERNAME") ?? Environment.GetEnvironmentVariable("HOSTNAME");

            if (hostname == "unnombre")
            {
                cs = builder.Configuration.GetConnectionString("EstacionamientoCSMAC");
            }
            #endregion

            builder.Services.AddDbContext<MiDb_C>(options =>
                    options.UseSqlServer(cs)
                    );

            #region Identity Config

            builder.Services.AddIdentity<Persona,Rol>().AddEntityFrameworkStores<MiDb_C>();

            //builder.Services.Configure<IdentityOptions>(opciones =>
            //{
            //    opciones.Password.RequireLowercase = false;
            //    opciones.Password.RequireNonAlphanumeric = false;
            //    opciones.Password.RequireUppercase = false;
            //    opciones.Password.RequireDigit = false;
            //    opciones.Password.RequiredLength = 5; //Antes era 6, también se puede hacer en AddIdentity.
            //    opciones.User.RequireUniqueEmail = true;
            //});

            //builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            //    opciones =>
            //    {
            //        opciones.LoginPath = "//Account/IniciarSesion";
            //        opciones.AccessDeniedPath = "//Account/AccesoDenegado";
            //        opciones.Cookie.Name = "EstacionamientoCookie";
            //    });

            #endregion

            builder.Services.AddControllersWithViews();

            var app = builder.Build();


            // Poblar la base de datos con datos de ejemplo
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MiDb_C>();
                    SeedData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocurrió un error al poblar la base de datos.");
                }
            }





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

         


        }
    }
}
