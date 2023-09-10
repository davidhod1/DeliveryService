namespace API.DTOs;

public class CreateVehicleDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public int ProductionYear { get; set; }
    public double MaxLoadCapacity { get; set; }
    public double XCoordinate { get; set; }
    public double YCoordinate { get; set; }
    public string AdditionalInfo { get; set; }
}
