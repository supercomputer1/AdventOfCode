using System.Text.RegularExpressions;
using Helpers;
// ReSharper disable MoveLocalFunctionAfterJumpStatement
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

var input = FileUtils.GetInput("input.txt");

static int PartOne(string memory)
{
    var pairs = GetPairs(memory);
    return pairs.Sum(p => p.Multiply());
}

static int PartTwo(string memory)
{
    const string doPattern = @"do\(\)";
    const string dontPattern = @"don't\(\)";

    var doInstructions = Regex.Matches(memory, doPattern).Select(s => new Instruction(s.Index, true));
    var dontInstructions = Regex.Matches(memory, dontPattern).Select(s => new Instruction(s.Index, false));

    var instructions = GetInstructions(doInstructions, dontInstructions);

    List<Pair> pairs = [];
    for (var i = 0; i < instructions.Count; i++)
    {
        var instruction = instructions[i];

        if (!instruction.Enabled) continue;

        if (i + 1 > instructions.Count - 1)
        {
            pairs.AddRange(GetPairs(memory[instruction.Index..]));
        }
        else
        {
            pairs.AddRange(GetPairs(memory.Substring(instruction.Index, instructions[i + 1].Index - instruction.Index)));
        }
    }

    static List<Instruction> GetInstructions(IEnumerable<Instruction> first, IEnumerable<Instruction> second)
    {
        List<Instruction> instructions = [new(0, true)];
        instructions.AddRange(first);
        instructions.AddRange(second);

        return instructions.OrderBy(i => i.Index).ToList();
    }

    return pairs.Sum(p => p.Multiply());
}

Console.WriteLine(PartOne(string.Join("", input)));
Console.WriteLine(PartTwo(string.Join("", input)));


static IEnumerable<Pair> GetPairs(string memory)
{
    const string mulPattern = @"mul\(\d+,\d+\)";

    var matches = Regex.Matches(memory, mulPattern);

    foreach (Match match in matches)
    {
        var values = Regex.Replace(match.Value, "[^.0-9.,]", "").Split(",");
        yield return new Pair(Convert.ToInt32(values.First()), Convert.ToInt32(values.Last()));
    }
}


internal record Pair(int X, int Y)
{
    public int Multiply() => X * Y;
}

internal record Instruction(int Index, bool Enabled);