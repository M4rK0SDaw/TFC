using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Membresium
{
    public int MembresiaId { get; set; }

    public string MembresiaTipo { get; set; } = null!;

    public decimal MembresiaPrecio { get; set; }

    public string MembresiaDescripcionBeneficios { get; set; } = null!;

    public bool? MembresiaAccesoClases { get; set; }

    public bool? MembresiaAccesoInstalaciones { get; set; }

    public bool? MembresiaEstado { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
