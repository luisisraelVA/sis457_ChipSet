using System;
using System.Collections.Generic;

namespace WebChipset.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
