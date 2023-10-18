using System.ComponentModel.DataAnnotations;

namespace MyMVCapp.Models;

public class Spectacle
{
    public int SpectacleID { get; set; }
    public string? Title { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
}