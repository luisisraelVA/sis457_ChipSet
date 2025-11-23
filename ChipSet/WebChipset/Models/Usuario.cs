using System;
using System.Collections.Generic;

namespace WebChipset.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
