using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamientoMVC.C.Data;
using EstacionamientoMVC.C.Models;

namespace EstacionamientoMVC.C.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly MiDb_C _miDb;

        public DireccionesController(MiDb_C context)
        {
            _miDb = context;
        }

        public async Task<IActionResult> Index()
        {
            var miDb_C = _miDb.Direcciones.Include(d => d.Cliente);
            return View(await miDb_C.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        public IActionResult Create(string clienteid)
        {
            ViewBag.Clienteid = clienteid;

            ViewData["Id"]= new SelectList(_miDb.Clientes, "Id", "NombreCompleto");         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(direccion);
                await _miDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);

            //ModelState.AddModelError(string.Empty,"Algun otro error");
            //ModelState.AddModelError("CodigoPostal", "Un error diferente en codpos");

            return View(direccion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(direccion);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            
            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);
           
            return View(direccion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _miDb.Direcciones.Remove(direccion);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _miDb.Direcciones.Any(e => e.Id == id);
        }
    }
}
