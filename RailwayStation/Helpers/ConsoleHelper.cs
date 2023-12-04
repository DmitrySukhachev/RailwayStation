using RailwayStation.Models;

namespace RailwayStation.Helpers;
public static class ConsoleHelper
{
    public static long GetRailwayEntityIdFromConsoleInput() 
    {
        var isEntityIdEntred = false;
        var input = string.Empty;
        long entityId = 0;

        while (!isEntityIdEntred) {
            input = Console.ReadLine();
            if (isEntityIdEntred = Int64.TryParse(input, out entityId))
                Console.WriteLine($"Введен номер: {entityId}");
            else
                Console.WriteLine("Некорректно введен номер!");
        }

        return entityId;
    }
}
