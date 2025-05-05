using VehicleFleet.Domain.Enums;

namespace VehicleFleet.Domain.Entities;

public class Car : Vehicle
{
    public Car(ChassisId chassisId, string color) : base(chassisId, color)
    {
    }
    public override VehicleType Type => VehicleType.Car;
    public override int NumberOfPassengers => 5;
}
