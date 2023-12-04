using RailwayStation.Models;

namespace RailwayStation.Services;
public interface IRailwayStationService
{
    Models.RailwayStation GetRailwayStation();
    void FloodFillRailwayStation(RailwayPath railwayPath);
    void FindShortestPath(RailwayPath railwayPath, long startPointId, long endPointId);
}
