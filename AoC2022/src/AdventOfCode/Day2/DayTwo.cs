namespace AdventOfCode.Day2
{

    public static class DayTwo
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 2");
            var partOne = SolvePartOne(input);
            var partTwo = SolvePartTwo(input);

            Console.WriteLine($"Part one: {partOne}");
            Console.WriteLine($"Part two: {partTwo}");
        }

        public static int SolvePartOne(List<string> input)
        {
            // ROCK PAPER   
            // ROCK SCISSOR   
            // ROCK ROCK  

            // PAPER ROCK 
            // PAPER SCISSOR 
            // PAPER PAPER 

            // SCISSOR ROCK 
            // SCISSOR PAPER 
            // SCISSOR SCISSOR 

            // A = ROCK 
            // B = PAPER 
            // C = SCISSORS

            // X = 1 ROCK 
            // Y = 2 PAPER  
            // Z = 3 SCISSORS 

            int WIN = 6;
            int DRAW = 3;
            int LOSS = 0;

            var possibleMoves = new Dictionary<string, int>();
            possibleMoves.Add("AX", DRAW + 1);
            possibleMoves.Add("AY", WIN + 2);
            possibleMoves.Add("AZ", LOSS + 3);
            possibleMoves.Add("BX", LOSS + 1);
            possibleMoves.Add("BY", DRAW + 2);
            possibleMoves.Add("BZ", WIN + 3);
            possibleMoves.Add("CX", WIN + 1);
            possibleMoves.Add("CY", LOSS + 2);
            possibleMoves.Add("CZ", DRAW + 3);

            int points = 0;
            foreach (var i in input)
            {
                var key = i.Replace(" ", "");
                points += possibleMoves[key];
            }

            return points;

        }

        public static int SolvePartTwo(List<string> input)
        {
            // X = LOSE 
            // Y = DRAW
            // Z = WIN 

            int WIN = 6;
            int DRAW = 3;
            int LOSS = 0;

            var possibleMoves = new Dictionary<string, int>();
            possibleMoves.Add("AX", LOSS + 3);
            possibleMoves.Add("AY", DRAW + 1);
            possibleMoves.Add("AZ", WIN + 2);
            possibleMoves.Add("BX", LOSS + 1);
            possibleMoves.Add("BY", DRAW + 2);
            possibleMoves.Add("BZ", WIN + 3);
            possibleMoves.Add("CX", LOSS + 2);
            possibleMoves.Add("CY", DRAW + 3);
            possibleMoves.Add("CZ", WIN + 1);

            int points = 0;
            foreach (var i in input)
            {
                var key = i.Replace(" ", "");
                points += possibleMoves[key];
            }

            return points;
        }
    }
}
