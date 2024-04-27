namespace AdventOfCode.Day6
{
    public static class DaySix
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 6");

            Console.WriteLine($"Part one: {GetMarker(input.First(), 4)}");
            Console.WriteLine($"Part two: {GetMarker(input.First(), 14)}");
        }

        private static int GetMarker(string input, int size)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i - size < 0)
                {
                    continue;
                }

                var chars = input[(i - size)..(i)].ToCharArray();
                string word = new string(chars);

                if (word.Distinct().Count() == size)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
