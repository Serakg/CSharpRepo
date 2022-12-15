using System;
using System.Collections.Generic;

namespace MindigFenyesUIModul;

public partial class Munka
{
    public int MunkasId { get; set; }

    public string Nev { get; set; } = null!;

    public DateTime SzulDatum { get; set; }
}
