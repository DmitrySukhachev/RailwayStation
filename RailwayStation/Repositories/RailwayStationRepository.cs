using RailwayStation.Models;

namespace RailwayStation.Repositories;
public class RailwayStationRepository : IRailwayStationRepository
{
    public Models.RailwayStation GetRailwayStation() 
    {
        // Парк 1
        var park1 = new RailwayPark() {
            Id = 1,
            Name = "Парк 1",
            Paths = new List<RailwayPath>()
        };

        var path1 = new RailwayPath(1, "Путь 1", 5);

        path1.AddRailwayPoint(1, "А");
        path1.AddRailwayPoint(2, "Б");
        path1.AddRailwayPoint(3, "В");
        path1.AddRailwayPoint(4, "Г");
        path1.AddRailwayPoint(5, "Д");

        path1.AddRailwaySegment(0, 1); //Отрезок A-Б
        path1.AddRailwaySegment(1, 2); //Отрезок Б-В
        path1.AddRailwaySegment(0, 3); //Отрезок А-Г
        path1.AddRailwaySegment(3, 4); //Отрезок Г-Д

        var path2 = new RailwayPath(2, "Путь 2", 4);

        path2.AddRailwayPoint(6, "Е");
        path2.AddRailwayPoint(7, "Ё");
        path2.AddRailwayPoint(8, "Ж");
        path2.AddRailwayPoint(9, "З");

        path2.AddRailwaySegment(0, 3); //Отрезок Е-З
        path2.AddRailwaySegment(1, 2); //Отрезок Ё-Ж
        path2.AddRailwaySegment(1, 3); //Отрезок Ё-З
        path2.AddRailwaySegment(2, 3); //Отрезок Ж-З

        park1.Paths.Add(path1);
        park1.Paths.Add(path2);

        // Парк 2
        var park2 = new RailwayPark() {
            Id = 2,
            Name = "Парк 2",
            Paths = new List<RailwayPath>()
        };

        var path3 = new RailwayPath(3, "Путь 3", 7);

        path3.AddRailwayPoint(10, "И");
        path3.AddRailwayPoint(11, "Й");
        path3.AddRailwayPoint(12, "К");
        path3.AddRailwayPoint(13, "Л");
        path3.AddRailwayPoint(14, "М");
        path3.AddRailwayPoint(15, "Н");
        path3.AddRailwayPoint(16, "О");

        path3.AddRailwaySegment(0, 1); //Отрезок И-Й
        path3.AddRailwaySegment(1, 2); //Отрезок Й-К
        path3.AddRailwaySegment(1, 3); //Отрезок Й-Л
        path3.AddRailwaySegment(3, 2); //Отрезок Л-К
        path3.AddRailwaySegment(3, 6); //Отрезок Л-О
        path3.AddRailwaySegment(3, 4); //Отрезок Л-М
        path3.AddRailwaySegment(3, 5); //Отрезок Л-Н
        path3.AddRailwaySegment(4, 5); //Отрезок М-Н
        path3.AddRailwaySegment(5, 6); //Отрезок Н-О

        park2.Paths.Add(path3);

        var railwayStation = new Models.RailwayStation() {
            Id = 1,
            Name = "Станция 1",
            Parks = new List<RailwayPark>() { park1, park2 }
        };

        return railwayStation;
    }
}
