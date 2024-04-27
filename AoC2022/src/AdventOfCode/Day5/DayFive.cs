namespace AdventOfCode.Day5
{
    public static class DayFive
    {
        public static void Solve(List<string> input)
        {

            Console.WriteLine("Day 5");
            // bug
            input.Remove(input.Last());

            var movements = ParseMovement(input.Skip(9).ToList());

            var crates = ParseCrates().ToList();
            foreach (var movement in movements)
            {
                for (int i = 0; i < movement.quantity; i++)
                {
                    crates[movement.to].Push(crates[movement.from].Pop());
                }
            }

            var crates2 = ParseCrates().ToList();
            foreach (var movement in movements)
            {
                var stack = new Stack<char>();
                for (int i = 0; i < movement.quantity; i++)
                {
                    stack.Push(crates2[movement.from].Pop());
                }

                while (stack.TryPop(out var c))
                {
                    crates2[movement.to].Push(c);
                }
            }

            Console.WriteLine($"Part one: {string.Join("", crates.Select(s => s.First()).ToList())}");
            Console.WriteLine($"Part two: {string.Join("", crates2.Select(s => s.First()).ToList())}");
        }



        private static IEnumerable<Stack<char>> ParseCrates()
        {
            var crates = new List<List<char>>()
            {
                new List<char>() { ' ' }, // hack to make list index 1 based
                new List<char>(){'B', 'V', 'W', 'T', 'Q', 'N', 'H', 'D'},
                new List<char>(){'B', 'W', 'D'},
                new List<char>(){'C', 'J', 'W', 'Q', 'S', 'T'},
                new List<char>(){'P', 'T', 'Z', 'N', 'R', 'J', 'F'},
                new List<char>(){'T', 'S', 'M', 'J', 'V', 'P', 'G'},
                new List<char>(){'N', 'T', 'F', 'W', 'B'},
                new List<char>(){'N', 'V', 'H', 'F', 'Q', 'D', 'L', 'B'},
                new List<char>(){'R', 'F', 'P', 'H'},
                new List<char>(){'H', 'P', 'N', 'L', 'B', 'M', 'S', 'Z'},
            };

            foreach (var crate in crates)
            {
                crate.Reverse(); // meh
                yield return new Stack<char>(crate);
            }
        }

        private static IEnumerable<(int quantity, int from, int to)> ParseMovement(List<string> input)
        {
            foreach (var i in input)
            {
                var movement = i.Split();

                int quantity = Convert.ToInt32(movement[1]);
                int from = Convert.ToInt32(movement[3]);
                int to = Convert.ToInt32(movement[5]);

                yield return (quantity, from, to);
            }

        }
    }
}
