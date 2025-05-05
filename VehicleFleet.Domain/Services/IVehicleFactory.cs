using VehicleFleet.Domain.Entities;
using VehicleFleet.Domain.Request;


namespace VehicleFleet.Domain.Services;

public interface IVehicleFactory
{
    Vehicle Create(CreateVehicleRequest resquest);
}
