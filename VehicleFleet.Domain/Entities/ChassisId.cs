namespace VehicleFleet.Domain.Entities;

public class ChassisId : Common.ChassisId
{
    public ChassisId(string series, uint number)
    {
        Series = series;
        Number = number;
    }
}
