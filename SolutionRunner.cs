using System.Diagnostics;

namespace Advent_of_Code_2023;

public static class SolutionRunner
{
    private static readonly List<DaySolution> Days =
    [
        new DayOne(1),
        new DayTwo(2),
    ];

    private static readonly Stopwatch Stopwatch = new Stopwatch();

    public static void Run()
    {
        var previousConfig = LoadConfig();
        Console.WriteLine($"Debug ([t]rue/[f]alse)? Leave empty to run previous: {previousConfig.Item1}");
        var debugAnswer = Console.ReadLine() ?? previousConfig.Item1;
        Console.WriteLine($"What part(s) to run (1/2)? Leave empty to run previous: {previousConfig.Item2}");
        var partAnswer = Console.ReadLine() ?? previousConfig.Item2;
        Console.WriteLine($"What day(s) to run? Leave empty to run previous: {previousConfig.Item3}");
        var dayAnswer = Console.ReadLine() ?? previousConfig.Item3;
        if (debugAnswer.FirstOrDefault() != 't' || debugAnswer.FirstOrDefault() != 'f' ||
            char.IsDigit(partAnswer.FirstOrDefault()) || char.IsDigit(dayAnswer.FirstOrDefault()))
        {
            Console.WriteLine("Something went wrong, please try again");
            Run();
        }

        var debug = debugAnswer.First() == 't';
        var daysToRun = dayAnswer.Split(",").Select(int.Parse).ToList();
        var partsToRun = partAnswer.Split(",").Select(int.Parse).ToList();
        foreach (var day in Days.Where(day => daysToRun.Contains(day.Day)))
        {
            Console.WriteLine($"Day {day.Day}");
            var input = ConvertInput(File.ReadAllText($"Input/Day{day.Day}.txt"), true);
            if (partsToRun.Contains(1))
            {
                Console.WriteLine("Part One:");
                TimeSolution(day.PartOne, input);
                Console.WriteLine($"Elapsed time: {Stopwatch.ElapsedMilliseconds} ms");
            }

            if (partsToRun.Contains(2))
            {
                Console.WriteLine("Part Two:");
                TimeSolution(day.PartTwo, input);
                Console.WriteLine($"Elapsed time: {Stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }

    private static Tuple<string, string, string> LoadConfig()
    {
        throw new NotImplementedException();
    }

    private static List<string> ConvertInput(string input, bool removeLast)
    {
        return input.Split("\n").SkipLast(removeLast ? 1 : 0).ToList();
    }

    private static void TimeSolution(Func<IEnumerable<string>, int> solution, IEnumerable<string> input)
    {
        Stopwatch.Reset();
        Stopwatch.Start();
        solution(input);
        Stopwatch.Stop();
    }
}