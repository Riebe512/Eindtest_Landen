using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandenModel;

public class Taal
{
    [Key]
    public string TaalCode { get; set; }
    public string Naam {  get; set; }
    public ICollection<LandenTaal> LandenTalen { get; set; }
}
