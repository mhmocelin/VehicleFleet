using FluentAssertions;
using VehicleFleet.Domain.Enums;
using VehicleFleet.Domain.Request;
using VehicleFleet.Domain.Entities;
using VehicleFleet.Application.Aplication.Services;

namespace VehicleFleet.Unit.Application;

public class VehicleFactoryTests
{
    private readonly VehicleFactory _factory = new();

    [Fact]
    public void Create_ShouldReturnCar_WhenTypeIsCar()
    {
        var request = new CreateVehicleRequest
        {
            Type = VehicleType.Car,
            Color = "Red",
            ChassisId = new ChassisIdRequest
            {
                Series = "CAR",
                Number = 1001
            }
        };

        var vehicle = _factory.Create(request);

        vehicle.Should().BeOfType<Car>();
        vehicle.Color.Should().Be("Red");
        vehicle.ChassisId.ToString().Should().Be("CAR-1001");
    }

    [Fact]
    public void Create_ShouldReturnBus_WhenTypeIsBus()
    {
        var request = new CreateVehicleRequest
        {
            Type = VehicleType.Bus,
            Color = "Yellow",
            ChassisId = new ChassisIdRequest
            {
                Series = "BUS",
                Number = 2002
            }
        };

        var vehicle = _factory.Create(request);

        vehicle.Should().BeOfType<Bus>();
    }

    [Fact]
    public void Create_ShouldReturnTruck_WhenTypeIsTruck()
    {
        var request = new CreateVehicleRequest
        {
            Type = VehicleType.Truck,
            Color = "Blue",
            ChassisId = new ChassisIdRequest
            {
                Series = "TRK",
                Number = 3003
            }
        };

        var vehicle = _factory.Create(request);

        vehicle.Should().BeOfType<Truck>();
    }

    [Fact]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenTypeIsInvalid()
    {
        var request = new CreateVehicleRequest
        {
            Type = (VehicleType)999,
            Color = "Black",
            ChassisId = new ChassisIdRequest
            {
                Series = "INV",
                Number = 9999
            }
        };

        Action act = () => _factory.Create(request);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*Unknown vehicle type*");
    }
}
