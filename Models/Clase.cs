using System;
using System.Collections.Generic;

namespace Gimnasio.Models;

public partial class Clase
{
    public int ClaseId { get; set; }

    public string ClaseNombre { get; set; } = null!;

    public string ClaseDescripcion { get; set; } = null!;

    public int ClaseCapacidadMaxima { get; set; }

    public string ClaseDiaSemana { get; set; } = null!;

    public DateTime ClaseHoraInicio { get; set; }

    public TimeOnly ClaseDuracion { get; set; }

    public int? ClaseInstructorId { get; set; }

    public bool? ClaseEstado { get; set; }

    public virtual Trabajador? ClaseInstructor { get; set; }

    public virtual ICollection<Reservaclase> Reservaclases { get; set; } = new List<Reservaclase>();
}
