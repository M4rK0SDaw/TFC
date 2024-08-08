using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Trabajador
{
    public int TrabajadorId { get; set; }

    public string TrabajadorNombre { get; set; } = null!;

    public string TrabajadorApellidos { get; set; } = null!;

    public DateOnly TrabajadorFechaNacimiento { get; set; }

    public string TrabajadorDocIdent { get; set; } = null!;

    public string TrabajadorDireccion { get; set; } = null!;

    public string TrabajadorTelefono { get; set; } = null!;

    public string TrabajadorEmail { get; set; } = null!;

    public DateTime TrabajadorFechaAlta { get; set; }

    public DateOnly? TrabajadorFechaBaja { get; set; }

    public string TrabajadorCargo { get; set; } = null!;

    public decimal TrabajadorSalario { get; set; }

    public bool? TrabajadorEstado { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
