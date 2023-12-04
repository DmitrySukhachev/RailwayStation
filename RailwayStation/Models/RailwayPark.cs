namespace RailwayStation.Models;

// Класс парка
public class RailwayPark : AbstractRailwayEntity {
    public List<RailwayPath> Paths { get; set; }
    public override string GetDisplayName() => $"Парк '{this.Id}. {this.Name}'";
}
