using System.Text.Json;

public static class MoviesAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/movies.json"));


    public static List<MovieModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<MovieModel>>(json);
    }


    public static void WriteAll(List<MovieModel> movies)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(movies, options);
        File.WriteAllText(path, json);
    }
}