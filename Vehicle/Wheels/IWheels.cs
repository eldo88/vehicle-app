using System.Text.Json.Serialization;
using vehicle_app.Vehicle.Wheels;

namespace vehicle_app;

[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(Wheels), typeDiscriminator: "wheels")]
public interface IWheels
{
    public string WheelBrand { get; set; }
    public decimal Radius { get; set; }
}