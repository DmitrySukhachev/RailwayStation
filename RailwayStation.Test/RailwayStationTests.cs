using RailwayStation.Repositories;

namespace RailwayStation.Test;

public class RailwayStationTests
{
    private IRailwayStationRepository repository;
    private Models.RailwayStation railwayStation;

    [SetUp]
    public void Setup()
    {
        repository = new RailwayStationRepository();
        railwayStation = repository.GetRailwayStation();
    }

    [Test]
    public void TestRailwayParksCount()
    {
        Assert.That(railwayStation.Parks.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestRailwayPathsCount()
    {
        Assert.That(railwayStation.Parks[0].Paths.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestRailwayPointsCount()
    {
        
        Assert.That(railwayStation.Parks[0].Paths[0].Points.Count, Is.EqualTo(railwayStation.Parks[0].Paths[0].RailwayPointsNumber));
    }
}