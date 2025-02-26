using System.IO;
using System.Text.Json;

public class JsonController : IJsonController
{
    public void WriteJsonTofile(string path, Person person)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(person);
            File.WriteAllText(path, jsonData);
            Console.WriteLine($"JSON-data skrevet til fil: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved skriving av JSON til fil: {ex.Message}");
        }
    }

    public Person ReadJsonFromFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Person>(jsonData);
            }
            else
            {
                Console.WriteLine("Filen finnes ikke.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved lesing av JSON fra til: {ex.Message}");
            return null;
        }
    }

    public void EditJsonFile(string path, Person updatedPerson)
    {
        try
        {
            if (File.Exists(path))
            {
                string jsonData = JsonSerializer.Serialize(updatedPerson);
                File.WriteAllText(path, jsonData);
                Console.WriteLine($"Filen {path} har blitt oppdatert.");
            }
            else
            {
                Console.WriteLine("Filen finnes ikke og kan derfor ikke oppdateres");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved redigering av JSON-fil: {ex.Message}");
        }
    }

    public void DeleteJsonFile(string path)
    {

        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Filen {path} er slettet.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved sletting av fil: {ex.Message}");
        }
    }
}
