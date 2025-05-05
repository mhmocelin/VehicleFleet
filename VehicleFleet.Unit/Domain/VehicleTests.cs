using FluentAssertions;
using VehicleFleet.Domain.Enums;
using VehicleFleet.Domain.Entities;

namespace VehicleFleet.Unit.Domain;

public class VehicleTests
{
    [Fact]
    public void Car_ShouldHaveCorrectProperties()
    {
        var chassis = new ChassisId("CAR", 1234);
        var car = new Car(chassis, "Red");

        car.Type.Should().Be(VehicleType.Car);
        car.NumberOfPassengers.Should().Be(5);
        car.Color.Should().Be("Red");
        car.ChassisId.ToString().Should().Be("CAR-1234");
    }

    [Fact]
    public void Bus_ShouldHaveCorrectProperties()
    {
        var chassis = new ChassisId("BUS", 5678);
        var bus = new Bus(chassis, "Yellow");

        bus.Type.Should().Be(VehicleType.Bus);
        bus.NumberOfPassengers.Should().Be(42);
        bus.Color.Should().Be("Yellow");
    }

    [Fact]
    public void Truck_ShouldHaveCorrectProperties()
    {
        var chassis = new ChassisId("TRK", 9999);
        var truck = new Truck(chassis, "Blue");

        truck.Type.Should().Be(VehicleType.Truck);
        truck.NumberOfPassengers.Should().Be(1);
        truck.Color.Should().Be("Blue");
    }
}
