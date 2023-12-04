namespace RailwayStation.Models;
public class RailwayPoint : AbstractRailwayEntity
{
    public bool WasVisited { get; set; }

    public override string GetDisplayName() => $"Точка '{this.Id}. {this.Name}'";
}
