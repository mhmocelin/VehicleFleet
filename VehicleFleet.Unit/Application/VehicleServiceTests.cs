using NSubstitute;
using FluentAssertions;
using VehicleFleet.Domain.Enums;
using VehicleFleet.Domain.Request;
using VehicleFleet.Domain.Entities;
using VehicleFleet.Application.Aplication.Services;
using VehicleFleet.Domain.Services;

namespace VehicleFleet.Unit.Application;

public class VehicleServiceTests
{
    private readonly IVehicleFactory _vehicleFactory = Substitute.For<IVehicleFactory>();
    private readonly VehicleService _service;

    public VehicleServiceTests()
    {
        _service = new VehicleService(_vehicleFactory);
    }

    private static CreateVehicleRequest GetValidRequest(string series = "ABC", uint number = 1234, string color = "Red", VehicleType type = VehicleType.Car)
        => new()
        {
            ChassisId = new ChassisIdRequest { Series = series, Number = number },
            Color = color,
            Type = type
        };

    [Fact]
    public void Add_ShouldAddVehicle_WhenChassisIsUnique()
    {
        var request = GetValidRequest();
        var expectedVehicle = new Car(new ChassisId("ABC", 1234), "Red");

        _vehicleFactory.Create(request).Returns(expectedVehicle);

        _service.Add(request);
        var result = _service.GetByChassis("ABC", 1234);

        result.Should().Be(expectedVehicle);
    }

    [Fact]
    public void Add_ShouldThrowException_WhenVehicleAlreadyExists()
    {
        var request = GetValidRequest();
        var vehicle = new Car(new ChassisId("ABC", 1234), "Red");

        _vehicleFactory.Create(request).Returns(vehicle);

        _service.Add(request);

        Action act = () => _service.Add(request);

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Vehicle already exists.");
    }

    [Fact]
    public void GetByChassis_ShouldReturnNull_WhenNotFound()
    {
        var result = _service.GetByChassis("XYZ", 9999);

        result.Should().BeNull();
    }

    [Fact]
    public void UpdateColor_ShouldReturnTrue_WhenVehicleExists()
    {
        var request = GetValidRequest();
        var vehicle = new Car(new ChassisId("ABC", 1234), "Red");

        _vehicleFactory.Create(request).Returns(vehicle);

        _service.Add(request);

        var success = _service.UpdateColor("ABC", 1234, new ColorUpdateRequest { Color = "Blue" });

        success.Should().BeTrue();
        _service.GetByChassis("ABC", 1234)?.Color.Should().Be("Blue");
    }

    [Fact]
    public void UpdateColor_ShouldReturnFalse_WhenVehicleDoesNotExist()
    {
        var success = _service.UpdateColor("XXX", 8888, new ColorUpdateRequest { Color = "Green" });

        success.Should().BeFalse();
    }

    [Fact]
    public void UpdateColor_ShouldThrowException_WhenColorIsEmpty()
    {
        var request = GetValidRequest();
        var vehicle = new Car(new ChassisId("ABC", 1234), "Red");

        _vehicleFactory.Create(request).Returns(vehicle);
        _service.Add(request);

        Action act = () => _service.UpdateColor("ABC", 1234, new ColorUpdateRequest { Color = "" });

        act.Should().Throw<ArgumentException>()
            .WithMessage("Color must be provided.");
    }

}
