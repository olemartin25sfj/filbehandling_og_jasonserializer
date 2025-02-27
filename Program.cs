using System;
using System.ComponentModel;

namespace filbehandling_og_jasonserializer
{
    class Program
    {
        static void Main()
        {
            var jsonController = new JsonController();
            string jsonFilePath = "person.json";
            var jsonFileOperations = new JsonFileOperations(jsonController, jsonFilePath);

            while (true)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("JSON-FILHÅNDTERING");
                Console.WriteLine("1. Legg til person");
                Console.WriteLine("2. Vis alle personer");
                Console.WriteLine("3. Rediger person");
                Console.WriteLine("4. Slett person");
                Console.WriteLine("5. Avslutt programmet");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": jsonFileOperations.WriteToJsonFile(); break;
                    case "2": jsonFileOperations.ReadFromJsonFile(); break;
                    case "3": jsonFileOperations.EditJsonFile(); break;
                    case "4": jsonFileOperations.DeleteJsonFile(); break;
                    case "5": Console.WriteLine("Avslutter..."); return;
                    default: Console.WriteLine("Ugyldig valg, prøv igjen."); break;
                }
            }
        }


    }
}

