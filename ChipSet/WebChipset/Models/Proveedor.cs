using System;
using System.Collections.Generic;

namespace WebChipset.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
