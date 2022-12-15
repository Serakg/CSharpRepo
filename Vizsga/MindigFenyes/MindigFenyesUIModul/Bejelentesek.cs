using System;
using System.Collections.Generic;

namespace MindigFenyesUIModul;

public partial class Bejelentesek
{
    public int Id { get; set; }

    public string Cim { get; set; } = null!;

    public DateTime Idopont { get; set; }
}
