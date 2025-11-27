using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChipset.Models;

namespace WebChipset.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly LabChipSetContext _context;

        public ClientesController(LabChipSetContext context)
        {
            _context = context;
        }

        // GET: Clientes 
        public async Task<IActionResult> Index(string buscar)
        {
            var query = _context.Cliente.AsQueryable();


            if (!string.IsNullOrEmpty(buscar))
            {
                query = query.Where(c =>
                    c.Nombre.Contains(buscar) ||
                    c.Email.Contains(buscar) ||
                    c.Telefono.Contains(buscar));
            }


            ViewData["BusquedaActual"] = buscar;

            return View(await query.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono")] Cliente cliente)
        {

            ModelState.Remove("UsuarioRegistro");
            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Pedido");


            bool existeEmail = _context.Cliente.Any(c => c.Email == cliente.Email);
            if (existeEmail)
            {
                ModelState.AddModelError("Email", "Este correo ya está registrado.");
            }

            if (ModelState.IsValid)
            {

                cliente.FechaRegistro = DateTime.Now;
                cliente.UsuarioRegistro = User.Identity?.Name ?? "Admin";
                cliente.Estado = 1;

                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // POST: Clientes/CrearRapido 
        [HttpPost]
        public async Task<IActionResult> CrearRapido([FromBody] Cliente cliente)
        {
            ModelState.Remove("UsuarioRegistro");
            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Pedido");

            bool existeEmail = _context.Cliente.Any(c => c.Email == cliente.Email);
            if (existeEmail)
            {
                return Json(new { success = false, message = "Ese correo ya está registrado." });
            }

            if (ModelState.IsValid)
            {
                cliente.FechaRegistro = DateTime.Now;
                cliente.UsuarioRegistro = User.Identity?.Name ?? "Vendedor";
                cliente.Estado = 1;

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                return Json(new { success = true, data = new { id = cliente.Id, nombre = cliente.Nombre } });
            }

            return Json(new { success = false, message = "Datos inválidos. Revise los campos." });
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono,UsuarioRegistro,FechaRegistro,Estado")] Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();


            ModelState.Remove("Pedido");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Delete/5 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {

                cliente.Estado = 0;
                _context.Update(cliente);

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}