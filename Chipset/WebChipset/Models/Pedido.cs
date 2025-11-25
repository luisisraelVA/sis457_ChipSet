using System;
using System.Collections.Generic;

namespace WebChipset.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaPedido { get; set; }

    public decimal Total { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
