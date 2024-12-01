// ReSharper disable MoveLocalFunctionAfterJumpStatement
using Helpers;

var input = FileUtils.GetInput("input.txt");

var left = input.Select(s => Convert.ToInt32(s.Split().First().ToString())).ToList();
var right = input.Select(s => Convert.ToInt32(s.Split().Last().ToString())).ToList();

if (left.Count != right.Count)
{
    throw new Exception("Left and right col must be equal in size.");
}

static int PartOne(List<int> left, List<int> right)
{
    left.Sort();
    right.Sort();

    return left.Select((t, i) => Math.Abs(t - right[i])).Sum();
}

static int PartTwo(List<int> left, List<int> right)
{
    Dictionary<int, int> seen = [];
    foreach (var t in right.Where(t => !seen.TryAdd(t, 1)))
    {
        seen[t] += 1;
    }

    return left.Where(num => seen.ContainsKey(num)).Sum(num => num * seen[num]);
}

Console.WriteLine($"Part 1: {PartOne(left, right)}.");
Console.WriteLine($"Part 2: {PartTwo(left, right)}.");