namespace VehicleFleet.Domain.Request;

public class VehicleRequest
{
    public ChassisIdRequest ChassisId { get; set; } = new();
    public string Color { get; set; } = string.Empty;
}
