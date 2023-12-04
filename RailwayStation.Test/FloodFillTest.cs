using RailwayStation.Repositories;
using RailwayStation.Services;

namespace RailwayStation.Test;

public class FloodFillTest
{
    private IRailwayStationRepository repository;
    private IRailwayStationService service;
    private Models.RailwayStation railwayStation;
    private StringWriter stringWriter;

    [SetUp]
    public void Setup()
    {
        repository = new RailwayStationRepository();
        service = new RailwayStationService(repository);
        railwayStation = repository.GetRailwayStation();
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
    }

    [Test]
    public void TestFloodFill()
    {
        service.FloodFillRailwayStation(railwayStation.Parks[0].Paths[0]);
        var output = stringWriter.ToString();
        Assert.That(output, Is.EqualTo("Точка '1. А'\r\nТочка '2. Б'\r\nТочка '3. В'\r\nТочка '4. Г'\r\nТочка '5. Д'\r\n"));
    }
}
