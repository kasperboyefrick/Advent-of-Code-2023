using System.Diagnostics;

namespace Advent_of_Code_2023;

public static class SolutionRunner
{
    private static List<DaySolution> _days = new()
    {
        new DayOne(1),
        new DayTwo(2),
    };

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
            Run();
        }
        var config = (debugAnswer, partAnswer, dayAnswer);
    }

    private static Tuple<string, string, string> LoadConfig()
    {
        throw new NotImplementedException();
    }

    public static List<string> ConvertInput(string input, bool removeLast)
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