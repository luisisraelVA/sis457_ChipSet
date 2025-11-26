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
    public class PedidoesController : Controller
    {
        private readonly LabChipSetContext _context;

        public PedidoesController(LabChipSetContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index(string buscar)
        {
            var query = _context.Pedido
                .Include(p => p.IdClienteNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(buscar))
            {
                // Busca por Nombre de Cliente O por Número de ID
                query = query.Where(p =>
                    p.IdClienteNavigation.Nombre.Contains(buscar) ||
                    p.Id.ToString() == buscar);
            }

            ViewData["BusquedaActual"] = buscar;
            return View(await query.OrderByDescending(p => p.FechaPedido).ToListAsync());
        }
        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido

                .Include(p => p.IdClienteNavigation)

                .Include(p => p.DetallePedido)

                    .ThenInclude(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,FechaPedido,Total,UsuarioRegistro,FechaRegistro,Estado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", pedido.IdCliente);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", pedido.IdCliente);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,FechaPedido,Total,UsuarioRegistro,FechaRegistro,Estado")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", pedido.IdCliente);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedido.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }
    }
}
