namespace API.DTOs;

public class UpdateVehicleDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public int ProductionYear { get; set; }
    public double MaxLoadCapacity { get; set; }
    public string AdditionalInfo { get; set; }
}
