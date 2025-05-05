using VehicleFleet.Domain.Entities;
using VehicleFleet.Domain.Request;
using VehicleFleet.Domain.Services;

namespace VehicleFleet.Application.Aplication.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleFactory _vehicleFactory;
    public VehicleService(IVehicleFactory vehicleFactory) => _vehicleFactory = vehicleFactory;

    private readonly Dictionary<string, Vehicle> _vehicles = new();

    public void Add(CreateVehicleRequest vehicleRequest)
    {
        var chassisId = vehicleRequest.ChassisId.ToString();

        if (_vehicles.ContainsKey(chassisId))
            throw new InvalidOperationException("Vehicle already exists.");

        var newVehicle = _vehicleFactory.Create(vehicleRequest);

        _vehicles[chassisId] = newVehicle;
    }

    public IEnumerable<Vehicle> GetAll() => _vehicles.Values;

    public Vehicle? GetByChassis(string series, uint number)
    {
        var chassisId = new ChassisId(series, number);
        _vehicles.TryGetValue(chassisId.ToString(), out var vehicle);
        return vehicle;
    }

    public bool UpdateColor(string series, uint number, ColorUpdateRequest colorRequest)
    {
        var chassisId = new ChassisId(series, number);
        var chassisIdkey = chassisId.ToString();

        if (!_vehicles.ContainsKey(chassisIdkey)) 
            return false;

        if (string.IsNullOrWhiteSpace(colorRequest.Color))
            throw new ArgumentException("Color must be provided.");

        _vehicles[chassisIdkey].Color = colorRequest.Color;
        return true;
    }
}
