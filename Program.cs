// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Advent_of_Code_2023;

const bool debug = false;
const int solutionNumber = 2;

using var file =
    new StreamReader($"C:/Users/kafr/Dokumenter udanfor OneDrive/Advent of code inputs/{solutionNumber}.txt");
const string debugString =
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

var input = SolutionRunner.ConvertInput(debug ? debugString : file.ReadToEnd(), !debug);

var colors = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };

var watch = new Stopwatch();

Console.WriteLine($"Execution of Solution {solutionNumber}. {(debug ? "DEBUG" : "")}");

PartOne(input, colors);

PartTwo(input);

void PartOne(List<string> input1, Dictionary<string, int> dictionary)
{
    Stopwatch watch1;
    watch1.Start();
    watch1.Stop();
    Console.WriteLine($"Result of first solution: {result1}. Execution time: {watch1.ElapsedMilliseconds} ms");
}

