using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string UsuarioNombre { get; set; } = null!;

    public string UsuarioApellidos { get; set; } = null!;

    public string UsuarioDocIdent { get; set; } = null!;

    public DateOnly UsuarioFechaNacimiento { get; set; }

    public string UsuarioDireccion { get; set; } = null!;

    public string UsuarioTelefono { get; set; } = null!;

    public string UsuarioEmail { get; set; } = null!;

    public DateTime UsuarioFechaAlta { get; set; }

    public DateOnly? UsuarioFechaBaja { get; set; }

    public int UsuarioTipoMembresia { get; set; }

    public bool? UsuarioEstado { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Reservaclase> Reservaclases { get; set; } = new List<Reservaclase>();
}
