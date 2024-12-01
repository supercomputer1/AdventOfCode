var input = Helpers.FileUtils.GetInput("test.txt");

var numbers = input.First().Split(",").Select(int.Parse).ToList();


var test = input.Skip(2);

var x  = test.Skip(5).Take(5);

foreach (var z in x) 
{
    Console.WriteLine(z); 
}





public record Board
{
    public List<List<int>> Lines { get; set; } = [];
}
