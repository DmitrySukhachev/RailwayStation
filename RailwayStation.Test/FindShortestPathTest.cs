using RailwayStation.Repositories;
using RailwayStation.Services;

namespace RailwayStation.Test;

public class FindShortestPathTest
{
    private IRailwayStationRepository repository;
    private IRailwayStationService service;
    private Models.RailwayStation railwayStation;
    private StringWriter stringWriter;
    private long startPointId;
    private long endPointId;

    [SetUp]
    public void Setup()
    {
        repository = new RailwayStationRepository();
        service = new RailwayStationService(repository);
        railwayStation = repository.GetRailwayStation();
        startPointId = 10;
        endPointId = 14;
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
    }

    [Test]
    public void TestFindShortestPathBetweenFirstAndFourthPoints()
    {
        service.FindShortestPath(railwayStation.Parks[1].Paths[0], startPointId, endPointId);
        var output = stringWriter.ToString();
        Assert.AreEqual("Точка '10. И'\r\nТочка '11. Й'\r\nТочка '12. К'\r\nТочка '13. Л'\r\nТочка '14. М'\r\n", output);
    }
}
