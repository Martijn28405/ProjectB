using System.Text.Json;
// "T" is een "generic". Dit houdt in dat T een ander type heeft. 
// Het is dus mogelijk om elke keer als de JsonAccessor wordt aangemaakt het type dat opgeslagen moet worden te wijzigen.
// Zie voorbeeld in AccountsLogic & MoviesLogic
public class JsonAccessor<T>
{
    private string _path;

    public JsonAccessor(string path)
    {
        _path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, path));
    }

    public List<T> LoadAll()
    {
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<T>>(json);
    }

    public void WriteAll(List<T> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(_path, json);
    }
}
