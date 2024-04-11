using System;
using System.Collections.Generic;
using MVCCRUD2.Models.CamposEncuesta;

namespace MVCCRUD2.Models;

public partial class Encuesta
{
    public int EncuestaId { get; set; }

    public int? UserId { get; set; }

    public string? NombreEncuesta { get; set; }

    public string? DescripcionEncuesta { get; set; }

    public virtual ICollection<CamposEncuesta> CamposEncuesta { get; set; } = new List<CamposEncuesta>();

    public virtual Usuario? User { get; set; }

    public string? url { get; set; }
}
