namespace Helpers;

public static class FileUtils
{
    public static List<string> GetInput(string fileName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var path = currentDirectory.Contains("bin") ? $"../../../{fileName}" : fileName;
        var lines = File
            .ReadAllLines(path)
            .Select(s => s.Trim());

        return [.. lines];
    }
}