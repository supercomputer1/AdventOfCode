using day03;

var numbers = Helpers.FileUtils.GetInput("input.txt");

var powerConsumption = SubmarineDiagnostic.GetPowerConsumption(numbers);
Console.WriteLine($"Part one: {powerConsumption}.");

var lifeSupportRating = SubmarineDiagnostic.GetLifeSupportRating(numbers);
Console.WriteLine($"Part two: {lifeSupportRating}.");


