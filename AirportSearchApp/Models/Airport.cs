namespace AirportSearchApp.Models;

public class Airport
{
    public int Id { get; set; } // ID local para SQLite
    public string Name { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Email { get; set; }
    public string Scordova { get; set; } // Nombre personalizado
}
