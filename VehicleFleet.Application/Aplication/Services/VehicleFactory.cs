using VehicleFleet.Domain.Entities;
using VehicleFleet.Domain.Enums;
using VehicleFleet.Domain.Request;
using VehicleFleet.Domain.Services;

namespace VehicleFleet.Application.Aplication.Services;
public class VehicleFactory : IVehicleFactory
{
    public Vehicle Create(CreateVehicleRequest request)
    {
        var chassis = new ChassisId(request.ChassisId.Series, request.ChassisId.Number);

        Vehicle vehicle = request.Type switch
        {
            VehicleType.Bus => new Bus(chassis, request.Color),
            VehicleType.Truck => new Truck(chassis, request.Color),
            VehicleType.Car => new Car(chassis, request.Color),
            _ => throw new ArgumentOutOfRangeException(nameof(request.Type), "Unknown vehicle type")
        };

        return vehicle;
    }
}
