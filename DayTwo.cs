namespace Advent_of_Code_2023;

class DayTwo : DaySolution
{
    public DayTwo(int day) : base(day)
    {
    }

    public override int PartOne(IEnumerable<string> input)
    {
        var colors = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
        return input.Select(game => (int.Parse(game[5..game.IndexOf(':')]),
            game[(game.IndexOf(':') + 1)..].Split(";").Select(set =>
                    set.Split(",").Select(draw => draw.TrimStart().Split(" "))
                        .Select(draw => colors[draw[1]] < int.Parse(draw[0])).Aggregate((b, b1) => b || b1))
                .Aggregate((b, b1) => b || b1))).Where(tuple => !tuple.Item2).Select(tuple => tuple.Item1).Sum();
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        return input.Select(game =>
            game[(game.IndexOf(':') + 1)..].Split(';').Select(set =>
                    set.Split(',').Select(draw => draw.TrimStart().Split(" "))
                        .Select(draw => (int.Parse(draw[0]), draw[1])))
                .Select(set => (
                    set.FirstOrDefault(draw => draw.Item2 == "red").Item1,
                    set.FirstOrDefault(draw => draw.Item2 == "blue").Item1,
                    set.FirstOrDefault(draw => draw.Item2 == "green").Item1))
                .Aggregate((set, set1) => (Math.Max(set.Item1, set1.Item1), Math.Max(set.Item2, set1.Item2),
                    Math.Max(set.Item3, set1.Item3)))).Select(tuple => tuple.Item1 * tuple.Item2 * tuple.Item3).Sum();
    }
}