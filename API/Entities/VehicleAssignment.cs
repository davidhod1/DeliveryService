namespace API.Entities;

public class VehicleAssignment
{
    public int Id { get; set; }
    public DateTime AssignmentStartTime { get; set; }
    public DateTime? AssignmentEndTime { get; set; } 
    public Driver Driver { get; set; }
    public Vehicle Vehicle { get; set; }
}
