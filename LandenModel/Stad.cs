using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandenModel;

public class Stad
{
    [Key]
    public int StadNr { get; set; }
    public string Naam { get; set; }
    public string LandCode { get; set; }
    public Land Land { get; set; }
}
