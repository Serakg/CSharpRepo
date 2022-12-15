using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace MindigFenyesWebModul.Models
{
    public class HibaBejelentes
    {
        public string? Cim { get; set; }
        public DateTime BejelentesIdeje { get; set; }
    }
}
