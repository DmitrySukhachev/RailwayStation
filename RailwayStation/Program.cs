using Microsoft.Extensions.DependencyInjection;
using RailwayStation.Helpers;
using RailwayStation.Repositories;
using RailwayStation.Services;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IRailwayStationRepository, RailwayStationRepository>()
                .AddSingleton<IRailwayStationService, RailwayStationService>()
                .BuildServiceProvider();

var railwayStationService = serviceProvider.GetRequiredService<IRailwayStationService>();
var railwayStation = railwayStationService.GetRailwayStation();

Console.WriteLine($"Загружена {railwayStation.GetDisplayName()}\n");
Console.WriteLine($"Список доступных парков для {railwayStation.GetDisplayName()}:");

foreach (var park in railwayStation.Parks)
{
    Console.WriteLine(park.GetDisplayName());

    foreach (var path in park.Paths)
    {
        Console.WriteLine($"\nСписок доступных точек для {path.GetDisplayName()}");
        railwayStationService.FloodFillRailwayStation(path);
    }
    Console.WriteLine();
}

var parkId = -1L;
var pathId = -1L;
var startPointId = -1L;
var endPointId = -1L;

var isParkExisted = false;
var isPathExisted = false;
var isStartPointExisted = false;
var isEndPointExisted = false;

Console.WriteLine("Введите номер парка: ");

while (!isParkExisted)
{
    parkId = ConsoleHelper.GetRailwayEntityIdFromConsoleInput();
    isParkExisted = railwayStation.Parks.Any(park => park.Id == parkId);

    if (!isParkExisted) 
    {
        Console.WriteLine("Такого парка не существует: ");
        Console.WriteLine("Введите номер парка: ");
    }
}

Console.WriteLine("Введите номер пути: ");

while (!isPathExisted)
{
    pathId = ConsoleHelper.GetRailwayEntityIdFromConsoleInput();
    isPathExisted = railwayStation.Parks.Where(park => park.Id == parkId).FirstOrDefault()
        .Paths.Any(path => path.Id == pathId);

    if (!isPathExisted)
    {
        Console.WriteLine("Такого пути не существует: ");
        Console.WriteLine("Введите номер пути: ");
    }
}

Console.WriteLine("Введите номер начальной точки пути: ");

while (!isStartPointExisted)
{
    startPointId = ConsoleHelper.GetRailwayEntityIdFromConsoleInput();
    isStartPointExisted = railwayStation.Parks.Where(park => park.Id == parkId).FirstOrDefault()
        .Paths.Where(path => path.Id == pathId).FirstOrDefault()
        .Points.Any(point => point.Id == startPointId);

    if (!isStartPointExisted)
    {
        Console.WriteLine("Такой точки не существует: ");
        Console.WriteLine("Введите номер начальной точки пути: ");
    }
}

Console.WriteLine("Введите номер конечной точки пути: ");

while (!isEndPointExisted)
{
    endPointId = ConsoleHelper.GetRailwayEntityIdFromConsoleInput();
    isEndPointExisted = railwayStation.Parks.Where(park => park.Id == parkId).FirstOrDefault()
        .Paths.Where(path => path.Id == pathId).FirstOrDefault()
        .Points.Any(point => point.Id == endPointId);

    if (!isEndPointExisted)
    {
        Console.WriteLine("Такой точки не существует: ");
        Console.WriteLine("Введите номер конечной точки пути: ");
    }
}

Console.WriteLine($"Кратчайший путь между точками {startPointId} и {endPointId}: ");
var enteredPath = railwayStation.Parks.Where(park => park.Id == parkId).FirstOrDefault()
        .Paths.Where(path => path.Id == pathId).FirstOrDefault();

railwayStationService.FindShortestPath(enteredPath, startPointId, endPointId);

