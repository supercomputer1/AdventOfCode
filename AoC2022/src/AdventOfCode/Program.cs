using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;
using AdventOfCode.Day7;
using AdventOfCode.Day8;
using AdventOfCode.Util;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var adventOfCodeClient = new AdventOfCodeClient(configuration["Appsettings:AdventOfCodeSessionCookie"]);

DayOne.Solve(await adventOfCodeClient.GetInput(1));
DayTwo.Solve(await adventOfCodeClient.GetInput(2));
DayThree.Solve(await adventOfCodeClient.GetInput(3));
DayFour.Solve(await adventOfCodeClient.GetInput(4));
DayFive.Solve(await adventOfCodeClient.GetInput(5));
DaySix.Solve(await adventOfCodeClient.GetInput(6));
DaySeven.Solve(await adventOfCodeClient.GetInput(7));
DayEight.Solve(await adventOfCodeClient.GetInput(8));
