namespace RailwayStation.Models;
public class RailwayStation : AbstractRailwayEntity
{
    public List<RailwayPark> Parks { get; set; }
    public override string GetDisplayName() => $"Ж/Д станция '{this.Id}. {this.Name}'";
}
