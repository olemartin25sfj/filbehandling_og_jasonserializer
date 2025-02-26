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
        int age = int.Parse(Console.ReadLine());

        var person = new Person(name, age);
        _jsonController.WriteJsonTofile(_path, person);


    }

    public void ReadFromJsonFile()
    {
        var person = _jsonController.ReadJsonFromFile(_path);
        if (person != null)
        {
            Console.WriteLine($"Navn: {person.Name}, Alder: {person.Age}");
        }
    }

    public void EditJsonFile()
    {
        Console.Write("Skriv inn nytt navn: ");
        string name = Console.ReadLine();
        Console.Write("Skriv inn ny alder: ");
        int age = int.Parse(Console.ReadLine());

        var updatedPerson = new Person(name, age);
        _jsonController.EditJsonFile(_path, updatedPerson);
    }

    public void DeleteJsonFile()
    {
        Console.WriteLine("Er du sikker på at du vil slette filen? (ja/nei)");
        string confirm = Console.ReadLine().ToLower();
        if (confirm == "ja")
        {
            _jsonController.DeleteJsonFile(_path);
        }
    }
}

