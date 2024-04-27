namespace AdventOfCode.Day4
{
    public static class DayFour
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 4");

            var test = input.SelectMany(s => s.Split("\n")).Select(s => s.Split(","));

            int p1 = 0;
            int p2 = 0;
            foreach (var pair in test)
            {
                (int s1, int e1, int s2, int e2) = (Convert.ToInt32(pair[0].Split("-")[0]), Convert.ToInt32(pair[0].Split("-")[1]), Convert.ToInt32(pair[1].Split("-")[0]), Convert.ToInt32(pair[1].Split("-")[1]));

                if (s1 <= s2 && e2 <= e1 || s2 <= s1 && e1 <= e2)
                {
                    p1++;
                }

                if (!(e1 < s2 || e2 < s1))
                {
                    p2++;
                }
            }

            Console.WriteLine($"Part one: {p1}");
            Console.WriteLine($"Part two: {p2}");
        }
    }
}