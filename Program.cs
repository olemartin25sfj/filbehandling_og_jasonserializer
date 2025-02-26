using System;

namespace filbehandling_og_jasonserializer;

class Program
{
    static void Main()
    {
        var fileController = new FileController();
        string filePath = "data.txt";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("FILHÅNDTERING");
            Console.WriteLine("1. Skriv til fil (overskriv)");
            Console.WriteLine("2. Les fra fil");
            Console.WriteLine("3. Legg til tekst i fil");
            Console.WriteLine("4. Rediger fil (overskriv)");
            Console.WriteLine("5. Slett fil");
            Console.WriteLine("6. Avslutt program");
            Console.Write("Velg et alternativ: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Skriv inn tekst til filen: ");
                    string newText = Console.ReadLine();
                    fileController.WriteToFile(filePath, newText);
                    break;

                case "2":
                    string content = fileController.ReadFromFile(filePath);
                    Console.WriteLine("\nInnhold i filen:");
                    Console.WriteLine(content);
                    break;

                case "3":
                    Console.Write("Skriv inn tekst som skal legges til: ");
                    string additionalText = Console.ReadLine();
                    fileController.AppendToFile(filePath, additionalText);
                    break;

                case "4":
                    Console.Write("Er du sikker på at du vil overskrive filen? Dette sletter eksisterende data. (ja/nei): ");
                    string confirmEdit = Console.ReadLine()?.ToLower();
                    if (confirmEdit == "ja")
                    {
                        Console.Write("Skriv inn NYTT innhold til filen (overskriver eksisterende innhold): ");
                        string newContent = Console.ReadLine();
                        fileController.EditFile(filePath, newContent);
                    }
                    else
                    {
                        Console.WriteLine("Overskriving avbrutt.");
                    }
                    break;

                case "5":
                    Console.Write("Er du sikker på at du vil slette filen? (ja/nei): ");
                    string confirmDelete = Console.ReadLine()?.ToLower();
                    if (confirmDelete == "ja")
                    {
                        fileController.DeleteFile(filePath);
                    }
                    else
                    {
                        Console.WriteLine("Sletting avbrutt.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Avslutter...");
                    return;

                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;

            }

            Console.WriteLine("\nTrykk en tast for å fortsette...");
            Console.ReadKey();
        }
    }
}
