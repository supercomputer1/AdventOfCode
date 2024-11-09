var commands = Helpers.FileUtils.GetInput("input.txt");

// part one
var horizontalPositionPartOne = 0;
var depthPartOne = 0;

// part two
var horizontalPositionPartTwo = 0;
var depthPartTwo = 0;
var aim = 0;

foreach (var command in commands)
{
    var parts = command.Split(' ');
    var action = parts[0];
    var value = int.Parse(parts[1]);

    // part one
    switch (action)
    {
        case "forward":
            horizontalPositionPartOne += value;
            break;
        case "down":
            depthPartOne += value;
            break;
        case "up":
            depthPartOne -= value;
            break;
    }

    // part two
    switch (action)
    {
        case "forward":
            horizontalPositionPartTwo += value;
            depthPartTwo += aim * value;
            break;
        case "down":
            aim += value;
            break;
        case "up":
            aim -= value;
            break;
    }
}

long resultPartOne = horizontalPositionPartOne * depthPartOne;
long resultPartTwo = horizontalPositionPartTwo * depthPartTwo;

Console.WriteLine($"Part One: Result (Horizontal Position * Depth): {resultPartOne}");
Console.WriteLine($"Part Two: Result (Horizontal Position * Depth): {resultPartTwo}");