namespace VehicleFleet.Domain.Entities;

public abstract class Vehicle : Common.Vehicle
{
    protected Vehicle(Common.ChassisId chassisId, string color)
    {
        if (chassisId is null)
            throw new ArgumentNullException(nameof(chassisId));

        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color must be provided", nameof(color));

        ChassisId = chassisId;
        Color = color;
    }
}
