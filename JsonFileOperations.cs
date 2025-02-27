public class JsonFileOperations
{
    private readonly JsonController _jsonController;
    private readonly string _path;

    public JsonFileOperations(JsonController jsonController, string path)
    {
        _jsonController = jsonController;
        _path = path;
    }

    public void WriteToJsonFile()
    {
        Console.Write("Skriv inn navn: ");
        string name = Console.ReadLine();
        Console.Write("Skriv inn alder: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Ugyldig alder.");
            return;
        }

        var person = new Person(name, age);
        _jsonController.WriteJsonToFile(_path, person);
    }

    public void ReadFromJsonFile()
    {
        List<Person> people = _jsonController.ReadJsonFromFile(_path);
        if (people.Count > 0)
        {
            Console.WriteLine("\nPersoner i filen:");
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id}, Navn: {person.Name}, Alder: {person.Age}");
            }
        }
        else
        {
            Console.WriteLine("Ingen personer funnet.");
        }
    }

    public void EditJsonFile()
    {
        ReadFromJsonFile();
        Console.Write("\nSkriv inn ID til personen du vil redigere: ");
        string id = Console.ReadLine();
        Console.Write("Skriv inn nytt navn: ");
        string newName = Console.ReadLine();
        Console.Write("Skriv inn ny alder: ");
        if (!int.TryParse(Console.ReadLine(), out int newAge))
        {
            Console.WriteLine("Ugyldig alder.");
            return;
        }

        _jsonController.EditJsonFile(_path, id, newName, newAge);
    }

    public void DeleteJsonFile()
    {
        ReadFromJsonFile();
        Console.Write("Skriv inn ID til personen du vil slette, eller skriv 'ALL' for å slette hele filen: ");
        string id = Console.ReadLine();

        Console.Write("Er du sikker? (ja/nei): ");
        string confirm = Console.ReadLine().ToLower();

        if (confirm == "ja")
        {
            _jsonController.DeleteJsonFile(_path, id);
        }
    }
}