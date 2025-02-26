using System;

namespace filbehandling_og_jasonserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonController = new JsonController();
            string jsonFilePath = "person.json";

            var jsonFileOperations = new JsonFileOperations(jsonController, jsonFilePath);

            while (true)
            {

                Console.WriteLine(new string('-', 30));
                Console.WriteLine("JSON-FILHÅNDTERING");
                Console.WriteLine("1. Skriv til JSON-fil");
                Console.WriteLine("2. Les fra JSON-fil");
                Console.WriteLine("3. Rediger JSON-fil");
                Console.WriteLine("4. Slett JSON-fil");
                Console.WriteLine("5. Avslutt program");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        jsonFileOperations.WriteToJsonFile();
                        break;

                    case "2":
                        jsonFileOperations.ReadFromJsonFile();
                        break;

                    case "3":
                        jsonFileOperations.EditJsonFile();
                        break;

                    case "4":
                        jsonFileOperations.DeleteJsonFile();
                        break;

                    case "5":
                        Console.WriteLine("Avslutter...");
                        return;

                    default:
                        Console.WriteLine("Ugyldig valg, prøv igjen.");
                        break;
                }
            }
        }
    }
}
