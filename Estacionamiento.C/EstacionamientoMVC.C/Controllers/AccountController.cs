using EstacionamientoMVC.C.Data;
using EstacionamientoMVC.C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiDb_C _context;
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signInManager;
        private readonly RoleManager<Rol> _roleManager;

        public AccountController(
            MiDb_C context,
            UserManager<Persona> userManager,
            SignInManager<Persona> signInManager,
            RoleManager<Rol> roleManager
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }


        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login model)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.Recordarme,false);

                if (resultado.Succeeded)
                {
                    //veo que hago
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty,"Inicio de sesión incorrecto");
            }

            return View(model);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Registrar model)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                { 
                    UserName = model.UserName,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Email = model.Email
                };
                
                var resultado = await _userManager.CreateAsync(cliente,model.Password);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index","Clientes");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

            }

            return View();
        }


    }
}
