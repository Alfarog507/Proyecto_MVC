using System;
using System.Collections.Generic;

namespace MVCCRUD2.Models;

public partial class CamposEncuesta
{
    public int CampoId { get; set; }

    public int? EncuestaId { get; set; }

    public string? NombreCampo { get; set; }

    public bool? EsRequerido { get; set; }

    public string? TipoCampo { get; set; }

    public virtual Encuesta? Encuesta { get; set; }
}
