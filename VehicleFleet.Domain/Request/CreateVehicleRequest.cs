using VehicleFleet.Domain.Enums;

namespace VehicleFleet.Domain.Request;

public class CreateVehicleRequest : VehicleRequest
{
    public VehicleType Type { get; set; }
}
