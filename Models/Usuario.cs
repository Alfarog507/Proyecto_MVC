using System;
using System.Collections.Generic;

namespace MVCCRUD2.Models;

public partial class Usuario
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();
}
