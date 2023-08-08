using System.Text.Json;
// "T" is een "generic". Dit houdt in dat T een ander type heeft. 
// Het is dus mogelijk om elke keer als de JsonAccessor wordt aangemaakt het type dat opgeslagen moet worden te wijzigen.
// Zie voorbeeld in AccountsLogic & MoviesLogic
public class JsonAccessor<T>
{
    private string _path;

    public JsonAccessor(string path)
    {
        _path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, path));
    }

    public List<T> LoadAll()
    {
        try
        {
            // Attempt to read the JSON file contents
            string json = File.ReadAllText(_path);           
            // Deserialize JSON data into a list of objects
            return JsonSerializer.Deserialize<List<T>>(json);
        }
        catch (FileNotFoundException ex)
        {
            // Handle the case where the file is not found
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (JsonException ex)
        {
            // Handle JSON parsing errors
            Console.WriteLine("Error parsing JSON data: " + ex.Message);
        }
        // Return an empty list if an exception occurred
        return new List<T>();
    }

    public void WriteAll(List<T> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(_path, json);
    }
}
