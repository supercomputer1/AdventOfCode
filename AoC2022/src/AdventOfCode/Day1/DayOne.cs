namespace AdventOfCode.Day1
{
    public static class DayOne
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 1");

            var result = new List<int>();
            int counter = 0;

            foreach (var i in input)
            {
                if (i == string.Empty)
                {
                    result.Add(counter);
                    counter = 0;
                }
                else
                {
                    counter += Convert.ToInt32(i);
                }
            }


            Console.WriteLine($"Part one: {result.Max(m => m)}");
            Console.WriteLine($"Part two: {result.OrderBy(o => o).TakeLast(3).Sum(s => s)}");
        }
    }
}
