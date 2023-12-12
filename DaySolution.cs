namespace Advent_of_Code_2023;

public abstract class DaySolution
{
    protected DaySolution(int day)
    {
        Day = day;
    }

    public int Day;
    public abstract int PartOne(IEnumerable<string> input);
    public abstract int PartTwo(IEnumerable<string> input);
}