using RailwayStation.Models;
using RailwayStation.Repositories;

namespace RailwayStation.Services;
public class RailwayStationService : IRailwayStationService
{
    private readonly IRailwayStationRepository railwayStationRepository;
    private readonly Stack<int> pointStack;
    private readonly Queue<int> pointQueue;
    public RailwayStationService(IRailwayStationRepository railwayStationRepository) 
    {
        this.railwayStationRepository = railwayStationRepository;
        this.pointStack = new Stack<int>();
        this.pointQueue = new Queue<int>();
    }
    public Models.RailwayStation GetRailwayStation() => railwayStationRepository.GetRailwayStation();
    public void FloodFillRailwayStation(RailwayPath railwayPath) 
    {
        railwayPath.Points[0].WasVisited = true;
        Console.WriteLine(railwayPath.Points[0].GetDisplayName());
        pointStack.Push(0);

        while (pointStack.Count > 0) {
            pointStack.TryPeek(out var currentPointIndex);
            var adjPointIndex = railwayPath.GetAdjUnvisitedPoint(currentPointIndex);

            if (adjPointIndex == -1)
                pointStack.Pop();
            else {
                railwayPath.Points[adjPointIndex].WasVisited = true;
                Console.WriteLine(railwayPath.Points[adjPointIndex].GetDisplayName());
                pointStack.Push(adjPointIndex);
            }
        }

        for (var i = 0; i < railwayPath.CurNumPoints; i++) {
            railwayPath.Points[i].WasVisited = false; // Сбросов флагов
        }
    }
    public void FindShortestPath(RailwayPath railwayPath, long startPointId, long endPointId) {

        var startPoint = railwayPath.Points.Where(p => p.Id == startPointId).FirstOrDefault();
        var startPointIndex = Array.IndexOf(railwayPath.Points, startPoint);
        var endPoint = railwayPath.Points.Where(p => p.Id == endPointId).FirstOrDefault();
        var endPointIndex = Array.IndexOf(railwayPath.Points, endPoint);
        var startPointWasVisited = false;
        var endPointWasVisited = false;
        
        railwayPath.Points[0].WasVisited = true;  
        pointQueue.Enqueue(0);
        int adjPointIndex;

        while (pointQueue.Any()) 
        {
            var currentPointIndex = pointQueue.Dequeue();

            if (!startPointWasVisited && currentPointIndex == startPointIndex) 
            {
                Console.WriteLine(railwayPath.Points[currentPointIndex].GetDisplayName());
                startPointWasVisited = true;
            }
            else if (!endPointWasVisited && currentPointIndex == endPointIndex) {
                Console.WriteLine(railwayPath.Points[currentPointIndex].GetDisplayName());
                endPointWasVisited = true;
            }
            else if (currentPointIndex > startPointIndex && currentPointIndex < endPointIndex)
                Console.WriteLine(railwayPath.Points[currentPointIndex].GetDisplayName());
            
            while ((adjPointIndex = railwayPath.GetAdjUnvisitedPoint(currentPointIndex)) != -1) 
            {
                railwayPath.Points[adjPointIndex].WasVisited = true;
                pointQueue.Enqueue(adjPointIndex);
            }
        }

        for (var i = 0; i < railwayPath.CurNumPoints; i++) {
            railwayPath.Points[i].WasVisited = false; // Сбросов флагов
        }
    }  
}
