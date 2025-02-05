namespace TouristApp.Domain.Models.Coordinate;

public struct Coordinate
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public double Accuracy { get; set; }
}