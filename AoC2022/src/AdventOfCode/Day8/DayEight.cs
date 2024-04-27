using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    public static class DayEight
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 8");

            var trees = new Dictionary<int, List<int>>();

            for (int i = 0; i < input.Count; i++)
            {
                var chars = new List<int>();
                for (int j = 0; j < input[i].Length; j++)
                {
                    var c = input[i][j].ToString();
                    chars.Add(Convert.ToInt32(c));
                }
                trees.Add(i, chars);
            }



            int p1 = 0;
            int p2 = 0;
            foreach (var tree in trees)
            {
                var col = tree.Key;

                int counter = 0;
                for (int i = 0; i < tree.Value.Count; i++)
                {
                    var down = new List<int>();
                    for (int j = col + 1; j < trees.Count; j++)
                    {
                        var oneDown = trees[j][i];
                        down.Add(oneDown);
                    }

                    var up = new List<int>();
                    for (int j = col - 1; j >= 0; j--)
                    {
                        var oneUp = trees[j][i];
                        up.Add(oneUp);
                    }

                    var left = tree.Value.Take(counter).ToList();
                    var right = tree.Value.Skip(counter + 1).ToList();

                    if (IsVisible(tree.Value[i], left, right, up, down)) p1++;

                    var currentScore = CalculateScenicScore(tree.Value[i], left, right, up, down);
                    if (currentScore > p2) p2 = currentScore;

                    counter++;
                }
            }

            Console.WriteLine($"Part one: {p1}");
            Console.WriteLine($"Part two: {p2}");
        }

        public static bool IsVisible(int current, List<int> left, List<int> right, List<int> up, List<int> down)
        {
            // edges 
            if (!left.Any()) return true;
            if (!right.Any()) return true;
            if (!up.Any()) return true;
            if (!down.Any()) return true;

            var visibles = new List<bool>();
            visibles.Add(IsVisiblePerDirection(current, left));
            visibles.Add(IsVisiblePerDirection(current, right));
            visibles.Add(IsVisiblePerDirection(current, up));
            visibles.Add(IsVisiblePerDirection(current, down));

            return visibles.Any(a => a == true);
        }

        public static bool IsVisiblePerDirection(int current, List<int> trees)
        {
            foreach (var tree in trees)
            {
                if (tree >= current)
                {
                    return false;
                }
            }

            return true;
        }

        public static int CalculateScenicScore(int current, List<int> left, List<int> right, List<int> up, List<int> down)
        {
            var leftScore = Look(current, left, true);
            var rightScore = Look(current, right, false);
            var upScore = Look(current, up, false);
            var downScore = Look(current, down, false);

            var score = leftScore * rightScore * upScore * downScore;

            return score;
        }

        public static int Look(int current, List<int> trees, bool direction)
        {
            if (direction)
                trees.Reverse();

            int score = 0;
            foreach (var tree in trees)
            {
                score++;

                if (tree >= current)
                {
                    break;
                }
            }

            return score;
        }
    }
}
