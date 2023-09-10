namespace API.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public int? DriverId { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    public int ProductionYear { get; set; }
    public double MaxLoadCapacity { get; set; }
    public double XCoordinate { get; set; }
    public double YCoordinate { get; set; }
    public string AdditionalInfo { get; set; }
    public Driver Driver { get; set; }
    public ICollection<VehicleAssignment> AssignmentHistory { get; set; }

}
