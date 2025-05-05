using VehicleFleet.Domain.Enums;

namespace VehicleFleet.Domain.Entities;

public class Bus : Vehicle
{
    public Bus(ChassisId chassisId, string color) : base(chassisId, color) 
    {
    }
    public override VehicleType Type => VehicleType.Bus;
    public override int NumberOfPassengers => 42;
}
