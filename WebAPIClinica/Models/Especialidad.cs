using System;
using System.Collections.Generic;

namespace WebAPIClinica.Models;

public partial class Especialidad
{
    public string Codesp { get; set; } = null!;

    public string Nomesp { get; set; } = null!;

    public decimal? Costo { get; set; }

    public string? Eliminado { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
