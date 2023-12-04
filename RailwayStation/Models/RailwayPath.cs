namespace RailwayStation.Models;

// Класс пути
public class RailwayPath : AbstractRailwayEntity
{ 
    public int RailwayPointsNumber { get; set; } // Kоличетво точек ж/д станции
    public RailwayPoint[] Points { get; private set; }  // Массив точек ж/д станции
    public int[][] SegmentAdjMatrix { get; private set; } // Матрица смежности, представляющая отрезки пути
    public int CurNumPoints { get; private set; } // Текущее количество вершин

    public RailwayPath(long id, string name, int railwayPointsNumber) {
        Id = id;
        Name = name;
        RailwayPointsNumber = railwayPointsNumber;
        SegmentAdjMatrix = new int[RailwayPointsNumber][];
        Points = new RailwayPoint[RailwayPointsNumber];

        for (var i = 0; i < RailwayPointsNumber; i++) {
            SegmentAdjMatrix[i] = new int[RailwayPointsNumber];

            for (var j = 0; j < RailwayPointsNumber; j++) {
                SegmentAdjMatrix[i][j] = 0;
            }
        }
    }

    public void AddRailwayPoint(long id, string pointName) {
        Points[CurNumPoints++] = new RailwayPoint {
            Id = id,
            Name = pointName
        };
    }

    public void AddRailwaySegment(int start, int end) {
        SegmentAdjMatrix[start][end] = 1;
        SegmentAdjMatrix[end][start] = 1;
    }

    public int GetAdjUnvisitedPoint(int p) {
        for (var j = 0; j < CurNumPoints; j++) {
            if (SegmentAdjMatrix[p][j] == 1 && !Points[j].WasVisited)
                return j;
        }

        return -1;
    }
    public override string GetDisplayName() => $"Путь '{this.Id}. {this.Name}'";
}
