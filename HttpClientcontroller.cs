using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Security;

public class HttpClientController
{
    private readonly HttpClient _Client;

    public HttpClientController()
    {
        _Client = new HttpClient();
    }

    public async Task<string> FetchDataFromApi(string url)
    {
        try
        {
            Console.WriteLine($"Henter data fra {url}...");
            string response = await _Client.GetStringAsync(url);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved henting av data: {ex.Message}");
            return string.Empty;
        }
    }

    public void SaveDataToFile(string data, string filePath)
    {
        if (!string.IsNullOrEmpty(data))
        {
            File.WriteAllText(filePath, data);
            Console.WriteLine($"Data lagret til {filePath}");
        }
        else
        {
            Console.WriteLine("Ingen data å lagre.");
        }
    }
}