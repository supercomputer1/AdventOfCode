namespace AdventOfCode.Day7
{
    public static class DaySeven
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 7");

            var path = new List<string>();
            var directories = new Dictionary<string, int>();

            foreach (var line in input)
            {
                var words = line.Trim().Split();

                if (words[1].Equals("cd"))
                {
                    if (words[2].Equals(".."))
                    {
                        path.RemoveAt(path.Count - 1);
                    }
                    else
                    {
                        path.Add(words[2]);
                    }
                }
                else if (words[1].Equals("ls"))
                {
                    continue;
                }
                else
                {
                    if (words[0].Equals("dir")) continue;
                    var score = int.Parse(words[0]);

                    for (int i = 1; i < path.Count + 1; i++)
                    {
                        var key = string.Join("/", path.Take(i));

                        if (directories.ContainsKey(key))
                        {
                            directories[key] += score;
                        }
                        else
                        {
                            directories.Add(key, score);
                        }
                    }
                }
            }

            Console.WriteLine($"Part one: {directories.Where(w => w.Value <= 100000).Sum(s => s.Value)}");

            int max = 70000000 - 30000000;
            int need =  directories["/"] - max;

            foreach (var dir in directories.OrderBy(o => o.Value))
            {
                if (dir.Value >= need)
                {
                    Console.WriteLine($"Part two: {dir.Value}");
                    break;
                }
            }
        }
    }
}
