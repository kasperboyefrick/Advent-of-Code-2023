namespace Advent_of_Code_2023;

class DayOne : DaySolution
{
    public DayOne(int day) : base(day)
    {
    }

    public override int PartOne(IEnumerable<string> input)
    {
        return input.Select(s => int.Parse(s.First(char.IsDigit).ToString() + s.Last(char.IsDigit))).Sum();
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        var options = new Dictionary<string, int>()
        {
            { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 },
            { "eight", 8 }, { "nine", 9 }, { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
            { "7", 7 }, { "8", 8 }, { "9", 9 }
        };

        return input.Select(s => options.Keys.Select(k => (s.IndexOf(k), s.LastIndexOf(k), k, k))
                .Where(t => t.Item1 != -1)
                .Aggregate((tuple, valueTuple) => (tuple.Item1 < valueTuple.Item1 ? tuple.Item1 : valueTuple.Item1,
                    tuple.Item2 > valueTuple.Item2 ? tuple.Item2 : valueTuple.Item2,
                    tuple.Item1 < valueTuple.Item1 ? tuple.Item3 : valueTuple.Item3,
                    tuple.Item2 > valueTuple.Item2 ? tuple.Item4 : valueTuple.Item4)))
            .Select(t => int.Parse(options[t.Item3].ToString() + options[t.Item4])).Sum();
    }

}