using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandenModel;

public class LandenTaal
{
    public string LandCode { get; set; }
    public Land Land { get; set; }
    public string TaalCode { get; set; }
    public Taal Taal { get; set; }
}
