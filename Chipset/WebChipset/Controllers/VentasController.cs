using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebChipset.Models;
using WebChipset.Models.ViewModels;

namespace WebChipset.Controllers
{
    [Authorize]
    public class VentasController : Controller
    {
        private readonly FinalChipSetContext _context;

        public VentasController(FinalChipSetContext context)
        {
            _context = context;
        }

        // GET: Ventas/NuevaVenta
        public IActionResult NuevaVenta()
        {

            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Nombre");


            var productos = _context.Producto
                .Where(p => p.Stock > 0 && p.Estado == 1)
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.PrecioVenta,
                    p.Stock,

                    TextoMostrar = $"{p.Nombre} - {p.PrecioVenta:C}"
                })
                .ToList();


            ViewBag.ListaProductos = new SelectList(productos, "Id", "TextoMostrar");


            ViewBag.DatosProductos = productos;

            return View();
        }

        // POST: Ventas/GuardarVenta
        [HttpPost]
        public async Task<IActionResult> GuardarVenta([FromBody] VentaViewModel venta)
        {
            if (venta == null || venta.Detalles == null || venta.Detalles.Count == 0)
            {
                return Json(new { success = false, message = "El carrito está vacío." });
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                    var pedido = new Pedido
                    {
                        IdCliente = venta.IdCliente,
                        FechaPedido = DateOnly.FromDateTime(DateTime.Now),
                        Total = venta.Total,
                        UsuarioRegistro = "WebUser",
                        FechaRegistro = DateTime.Now,
                        Estado = 1
                    };

                    _context.Pedido.Add(pedido);
                    await _context.SaveChangesAsync();


                    foreach (var item in venta.Detalles)
                    {
                        var detalle = new DetallePedido
                        {
                            IdPedido = pedido.Id,
                            IdProducto = item.IdProducto,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario,
                            UsuarioRegistro = "WebUser",
                            FechaRegistro = DateTime.Now,
                            Estado = 1
                        };

                        var productoDB = await _context.Producto.FindAsync(item.IdProducto);
                        if (productoDB != null)
                        {
                            if (productoDB.Stock < item.Cantidad)
                            {
                                throw new Exception($"Stock insuficiente para: {productoDB.Nombre}");
                            }
                            productoDB.Stock -= item.Cantidad;
                        }

                        _context.DetallePedido.Add(detalle);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Json(new { success = true, message = "Venta guardada correctamente" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Json(new { success = false, message = "Error: " + ex.Message });
                }
            }
        }
    }
}
