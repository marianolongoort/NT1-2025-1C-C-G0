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
    public class TelefonosController : Controller
    {
        private readonly MiDb_C _miDb;

        public TelefonosController(MiDb_C midb)
        {
            _miDb = midb;
        }






        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var miDb_C = _miDb.Telefonos.Include(t => t.Cliente);
            return View(await miDb_C.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }













        // GET: Telefonos/Create
        public IActionResult Create()
        {

            var clientesEnDb = _miDb.Clientes;

            ViewData["ClienteId"] = new SelectList(clientesEnDb, "Id", "NombreCompleto");


            return View();
        }

        // POST: Telefonos/Create                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,ClienteId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(telefono);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "Apellido", telefono.ClienteId);
            return View(telefono);
        }



















        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "Apellido", telefono.ClienteId);
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,ClienteId")] Telefono telefono)
        {
            if (id != telefono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(telefono);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "Apellido", telefono.ClienteId);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _miDb.Telefonos.Remove(telefono);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _miDb.Telefonos.Any(e => e.Id == id);
        }
    }
}
