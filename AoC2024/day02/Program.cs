using Helpers;
// ReSharper disable MoveLocalFunctionAfterJumpStatement
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable AccessToModifiedClosure

var input = FileUtils.GetInput("input.txt");

var reports = input.Select(i => i.Split().Select(x => Convert.ToInt32(x))).ToList();

static int PartOne(List<IEnumerable<int>> reports)
{
    var result = 0;
    foreach (var report in reports)
    {
        var safe = IsSafe(report.ToList());

        if (safe)
        {
            result++;
        }
    }

    return result;
}

static int PartTwo(List<IEnumerable<int>> reports)
{
    var result = 0;
    foreach (var report in reports)
    {
        for (var i = 0; i < report.Count(); i++)
        {
            var combination = report.Where((_, j) => j != i);

            var safe = IsSafe(combination.ToList());

            if (!safe) continue;
            result++;
            break;
        }
    }

    return result;
}

static bool IsSafe(List<int> report)
{
    List<int> differences = [];
    for (var i = 0; i < report.Count; i++)
    {
        if (i == 0) continue;

        var difference = report[i - 1] - report[i];
        differences.Add(difference);
    }

    return differences.All(a => Math.Abs(a) > 0 && Math.Abs(a) < 4) &&
           differences.Select(Math.Sign).Distinct().Count() == 1;
}

Console.WriteLine(PartOne(reports));
Console.WriteLine(PartTwo(reports));