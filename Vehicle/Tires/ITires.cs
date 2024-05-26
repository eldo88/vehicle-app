using System.Text.Json.Serialization;

namespace vehicle_app;

[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(Tires), typeDiscriminator: "tires")]
public interface ITires
{
    public string BrandName { get; set; }
    public string Size { get; set; }
    public decimal Radius { get; set; }
}