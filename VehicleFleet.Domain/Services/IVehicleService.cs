using VehicleFleet.Domain.Entities;
using VehicleFleet.Domain.Request;

namespace VehicleFleet.Domain.Services;

public interface IVehicleService
{
    void Add(CreateVehicleRequest vehicleRequest);
    IEnumerable<Vehicle> GetAll();
    Vehicle GetByChassis(string series, uint number);
    bool UpdateColor(string series, uint number, ColorUpdateRequest colorRequest);
}
