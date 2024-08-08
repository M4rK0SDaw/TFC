using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int? PagoUsuarioId { get; set; }

    public decimal PagoMonto { get; set; }

    public DateTime PagoFecha { get; set; }

    public string PagoMetodo { get; set; } = null!;

    public int? PagoMembresiaId { get; set; }

    public string PagoEstado { get; set; } = null!;

    public virtual Membresium? PagoMembresia { get; set; }

    public virtual Usuario? PagoUsuario { get; set; }
}
