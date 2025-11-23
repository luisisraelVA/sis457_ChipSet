using System;
using System.Collections.Generic;

namespace WebChipset.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int IdProveedor { get; set; }

    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
