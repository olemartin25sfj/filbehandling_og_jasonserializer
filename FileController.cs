using System;
using System.IO;

public class FileController : IFileController
{
    public void WriteToFile(string path, string content)
    {
        try
        {
            File.WriteAllText(path, content);
            Console.WriteLine($"Innhold skrevet til fil: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved skriving til fil: {ex.Message}");
        }
    }

    public string ReadFromFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                return "File finnes ikke.";
            }
        }
        catch (Exception ex)
        {
            return $"Feil ved lesing fra fil: {ex.Message}";
        }
    }
    public void AppendToFile(string path, string content)
    {
        try
        {
            File.AppendAllText(path, content + Environment.NewLine);
            Console.WriteLine($"Innhold lagt til i filen: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved tillegg til fil: {ex.Message}");
        }
    }

    public void EditFile(string path, string newContent)
    {
        try
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, newContent);
                Console.WriteLine($"Filen {path} ble oppdatert.");
            }
            else
            {
                Console.WriteLine("Filen finnes ikke.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved redigering av fil: {ex.Message}");
        }
    }


    public void DeleteFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Filen {path} ble slettet.");
            }
            else
            {
                Console.WriteLine("Filen finnes ikke.");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved sletting av fil: {ex.Message}");
        }
    }

}