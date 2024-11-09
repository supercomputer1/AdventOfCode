namespace day03;

public static class SubmarineDiagnostic
{
    public static int GetLifeSupportRating(List<string> numbers)
    {
        var oxygenGeneratorRating = GetOxygenGeneratorRating(numbers.Select(s => s).ToList());
        var scrubberRating = GetScrubberRating(numbers.Select(s => s).ToList());
        
        return oxygenGeneratorRating * scrubberRating;
    }
    
    public static int GetPowerConsumption(List<string> numbers)
    {
        var gammaRate = GetGammaRate(numbers);
        var epsilonRate = GetEpsilonRate(gammaRate);
        
        return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2); 
    }

    private static string GetGammaRate(List<string> numbers)
    {
        var maxLength = numbers.First().Length;

        var gammaRate = string.Empty;
        for (var i = 0; i < maxLength; i++)
        {
            gammaRate += FindMostCommonBit(numbers, i);
        }

        return gammaRate;
    }

    private static int GetOxygenGeneratorRating(List<string> numbers)
    {
        var maxLength = numbers.First().Length;

        for (var i = 0; i < maxLength; i++)
        {
            var bit = FindMostCommonBit(numbers, i);
            var result = GetNumbersFromIndex(numbers, i, bit);

            numbers.Clear(); 
            numbers.AddRange(result);

            if (numbers.Count == 1) break;
        }
        
        return Convert.ToInt32(numbers.First(), 2);
    }
    
    private static int GetScrubberRating(List<string> numbers)
    {
        var maxLength = numbers.First().Length;

        for (var i = 0; i < maxLength; i++)
        {
            var bit = FindLeastCommonBit(numbers, i);
            var result = GetNumbersFromIndex(numbers, i, bit);

            numbers.Clear(); 
            numbers.AddRange(result);

            if (numbers.Count == 1) break;
        }
        
        return Convert.ToInt32(numbers.First(), 2);
    }

    private static string FindMostCommonBit(List<string> numbers, int column)
    {
        List<char> ones = [];
        List<char> zeroes = [];
        
        ones.AddRange(numbers.Select(t => t[column]).Where(binary => binary.Equals('1')));
        zeroes.AddRange(numbers.Select(t => t[column]).Where(binary => binary.Equals('0')));

        if (ones.Count == zeroes.Count) return "1";

        return ones.Count > zeroes.Count ? "1" : "0";
    }

    private static string FindLeastCommonBit(List<string> numbers, int column)
    {
        List<char> ones = [];
        List<char> zeroes = [];
        
        ones.AddRange(numbers.Select(t => t[column]).Where(binary => binary.Equals('1')));
        zeroes.AddRange(numbers.Select(t => t[column]).Where(binary => binary.Equals('0')));

        if (ones.Count == zeroes.Count) return "0";
        
        return ones.Count > zeroes.Count ? "0" : "1";   
    }

    private static string GetEpsilonRate(string gammaRate)
    {
        var epsilonRate = string.Empty;

        foreach (var c in gammaRate)
        {
            switch (c)
            {
                case '1':
                    epsilonRate += "0";
                    break;
                case '0':
                    epsilonRate += "1";
                    break;
            }
        }

        return epsilonRate;
    }
    
    private static List<string> GetNumbersFromIndex(List<string> numbers, int index, string bit)
    {
        List<string> result = [];
        result.AddRange(numbers.Where(num => num[index].ToString().Equals(bit)));

        return result; 
    }
}

