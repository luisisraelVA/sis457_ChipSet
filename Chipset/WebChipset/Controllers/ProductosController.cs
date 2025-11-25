using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChipset.Models;

namespace WebChipset.Controllers
{
    public class ProductosController : Controller
    {
        private readonly LabChipSetContext _context;

        public ProductosController(LabChipSetContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string buscar)
        {
            var query = _context.Producto
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdProveedorNavigation)
                .AsQueryable();


            if (!string.IsNullOrEmpty(buscar))
            {
                query = query.Where(p =>
                    p.Nombre.Contains(buscar) ||
                    p.IdCategoriaNavigation.Nombre.Contains(buscar) ||
                    p.IdProveedorNavigation.Nombre.Contains(buscar)
                );
            }


            ViewData["BusquedaActual"] = buscar;

            return View(await query.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["ListaCategorias"] = new SelectList(_context.Categoria, "Id", "Nombre");
            ViewData["ListaProveedores"] = new SelectList(_context.Proveedor, "Id", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProveedor,IdCategoria,Nombre,Descripcion,PrecioVenta,Stock,UsuarioRegistro,FechaRegistro,Estado")] Producto producto)
        {
            producto.FechaRegistro = DateTime.Now;
            producto.UsuarioRegistro = "Admin";

            ModelState.Remove("IdCategoriaNavigation");
            ModelState.Remove("IdProveedorNavigation");
            ModelState.Remove("UsuarioRegistro");
            ModelState.Remove("FechaRegistro");

            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListaCategorias"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.IdCategoria);
            ViewData["ListaProveedores"] = new SelectList(_context.Proveedor, "Id", "Nombre", producto.IdProveedor);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["ListaCategorias"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.IdCategoria);
            ViewData["ListaProveedores"] = new SelectList(_context.Proveedor, "Id", "Nombre", producto.IdProveedor);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProveedor,IdCategoria,Nombre,Descripcion,PrecioVenta,Stock,UsuarioRegistro,FechaRegistro,Estado")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }
            ModelState.Remove("IdCategoriaNavigation");
            ModelState.Remove("IdProveedorNavigation");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["ListaCategorias"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.IdCategoria);
            ViewData["ListaProveedores"] = new SelectList(_context.Proveedor, "Id", "Nombre", producto.IdProveedor);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto != null)
            {
                producto.Estado = 0;
                _context.Update(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.Id == id);
        }
    }
}
