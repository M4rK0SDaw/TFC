using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Reservaclase
{
    public int ReservaId { get; set; }

    public int? ReservaUsuarioId { get; set; }

    public int? ReservaClaseId { get; set; }

    public DateTime ReservaFecha { get; set; }

    public string ReservaEstado { get; set; } = null!;

    public virtual Clase? ReservaClase { get; set; }

    public virtual Usuario? ReservaUsuario { get; set; }
}
