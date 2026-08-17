using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandenModel;

public class Land
{
    [Key]
    public string LandCode { get; set; }
    public string Naam { get; set; }

    public ICollection<Stad> Steden { get; set; }
    public ICollection<LandenTaal> LandenTalen { get; set; }
}
