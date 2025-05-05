using VehicleFleet.Domain.Enums;

namespace VehicleFleet.Domain.Entities;

public class Truck : Vehicle
{
    public Truck(ChassisId chassisId, string color) : base(chassisId, color)
    {
    }
    public override VehicleType Type => VehicleType.Truck;
    public override int NumberOfPassengers => 1;
}
