namespace RailwayStation.Models;
public abstract class AbstractRailwayEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public abstract string GetDisplayName();
}
