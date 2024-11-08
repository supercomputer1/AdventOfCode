namespace Helpers;

public static class FileUtils
{
    public static List<string> GetInput(string fileName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        string path;
        if (currentDirectory.Contains("bin"))
        {
            path = $"../../../{fileName}";
        }
        else
        {
            path = fileName;
        }

        var lines = File
            .ReadAllLines(path)
            .Select(s => s.Trim());

        return [.. lines];
    }
}