namespace VehicleFleet.Domain.Common;

public class ChassisId
{
    public string Series { get; set; } = string.Empty;
    public uint Number { get; set; }
    public override string ToString() => $"{Series}-{Number}";
}
