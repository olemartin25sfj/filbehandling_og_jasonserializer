using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

public class JsonController : IJsonController
{
    public void WriteJsonToFile(string path, Person person)
    {
        try
        {
            List<Person> people = ReadJsonFromFile(path);
            person.Id = (people.Count + 1).ToString();
            people.Add(person);

            string jsonData = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonData);
            Console.WriteLine($"JSON-data skrevet til fil: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved skriving av JSON til fil: {ex.Message}");
        }
    }

    public List<Person> ReadJsonFromFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Person>>(jsonData) ?? new List<Person>();
            }
            return new List<Person>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved lesing av JSON-fil: {ex.Message}");
            return new List<Person>();
        }
    }

    public void EditJsonFile(string path, string id, string newName, int newAge)
    {
        try
        {
            List<Person> people = ReadJsonFromFile(path);
            var person = people.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                person.Name = newName;
                person.Age = newAge;

                string jsonData = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, jsonData);
                Console.WriteLine($"Person med ID {id} oppdatert.");
            }
            else
            {
                Console.WriteLine("Person ikke funnet.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved redigering av JSON-fil: {ex.Message}");
        }
    }

    public void DeleteJsonFile(string path, string id)
    {
        try
        {
            if (id == "ALL")
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Hele JSON-filen er slettet.");
                }
                else
                {
                    Console.WriteLine("Filen finnes ikke.");
                }
            }
            else
            {
                List<Person> people = ReadJsonFromFile(path);
                int countBefore = people.Count;
                people = people.Where(p => p.Id != id).ToList();

                if (countBefore == people.Count)
                {
                    Console.WriteLine("Ingen person med den ID-en ble funnet.");
                    return;
                }

                string jsonData = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, jsonData);
                Console.WriteLine($"Person med ID {id} slettet.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved sletting: {ex.Message}");
        }
    }
}