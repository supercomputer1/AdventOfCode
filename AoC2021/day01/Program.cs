var input = Helpers.FileUtils.GetInput("input.txt");

var measurements = input.Select(int.Parse).ToList();

var counter = 0;
for (var i = 0; i < measurements.Count; i++)
{
    if (i == 0) continue;
    if (measurements[i] > measurements[i - 1]) counter++;
}

Console.WriteLine($"Part one: {counter}.");

counter = 0;
for (int i = 0; i < measurements.Count - 2; i++)
{
    int currentSum = measurements[i] + measurements[i + 1] + measurements[i + 2];

    if (i > 0)
    {
        int previousSum = measurements[i - 1] + measurements[i] + measurements[i + 1];

        // Count increase  
        if (currentSum > previousSum)
        {
            counter++;
        }
    }
}

Console.WriteLine($"Part two: {counter}.");