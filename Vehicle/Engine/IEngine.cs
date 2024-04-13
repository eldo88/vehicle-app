using System.Text.Json.Serialization;

namespace vehicle_app;

[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(IEngine), typeDiscriminator: "base")]
[JsonDerivedType(typeof(GasEngine), typeDiscriminator: "gas")]
[JsonDerivedType(typeof(ElectricMotor), typeDiscriminator: "electric")]
[JsonDerivedType(typeof(DieselEngine), typeDiscriminator: "diesel")]
public interface IEngine
{
    int HorsePower { get; set; } 
    int Torque { get; set; }
    string FuelType { get; set; }
}
