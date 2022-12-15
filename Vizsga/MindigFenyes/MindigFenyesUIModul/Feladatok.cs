using System;
using System.Collections.Generic;

namespace MindigFenyesUIModul;

public partial class Feladatok
{
    public int FeladatId { get; set; }

    public string Tipus { get; set; } = null!;

    public int SzereloId { get; set; }

    public string Szerelo { get; set; } = null!;

    public string? Leiras { get; set; }

    public string Helyszin { get; set; } = null!;

    public DateTime BejDatum { get; set; }

    public DateTime BefejezDatum { get; set; }
}
