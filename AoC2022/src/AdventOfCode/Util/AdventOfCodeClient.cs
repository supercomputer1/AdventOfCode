namespace AdventOfCode.Util
{
    public class AdventOfCodeClient
    {
        private readonly HttpClient httpClient;

        public AdventOfCodeClient(string session)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("cookie", session);
        }

        public async Task<List<string>> GetInput(int day)
        {
            var response = await httpClient.GetAsync($"https://adventofcode.com/2022/day/{day}/input");
            response.EnsureSuccessStatusCode();

            var contents = await response.Content.ReadAsStringAsync();

            var result = contents.Split("\n").ToList();

            // well, because the last line of the input has a newline character we will have to remove that..
            if (string.IsNullOrWhiteSpace(result.Last()))
            {
                result.RemoveAt(result.IndexOf(result.Last()));
            }

            return result;
        }
    }
}
