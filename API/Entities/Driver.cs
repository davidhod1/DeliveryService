namespace API.Entities;

public class Driver
{   
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string  LastName { get; set; }
    public string LicenseNumber { get; set; }
    public ICollection<VehicleAssignment> AssignmentHistory { get; set; }
}
