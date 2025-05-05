using VehicleFleet.Domain.Enums;

namespace VehicleFleet.Domain.Common;

public abstract class Vehicle
{
    public ChassisId ChassisId { get; set; } = new();
    public string Color { get; set; } = string.Empty;
    public abstract VehicleType Type { get; }
    public abstract int NumberOfPassengers { get; }
}
