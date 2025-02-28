using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
public class HttpClientController
{
    private readonly HttpClient _Client;
    private readonly string _filePath = "pokemon_list.json";

    public HttpClientController()
    {
        _Client = new HttpClient();
    }

    public async Task<Pokemon>? FetchPokemonData(string pokemonName)
    {
        string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}";
        try
        {
            Console.WriteLine($"Henter data fra {pokemonName}...");
            string response = await _Client.GetStringAsync(url);
            return JsonSerializer.Deserialize<Pokemon>(response);

        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"Nettverksfeil ved henting av data: {httpEx.Message}");
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"Feil i derserialisering av JSON: {jsonEx.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Uventet feil: {ex.Message}");
            return null;
        }
    }

    public void SavePokemonToFile(Pokemon? pokemon)
    {

        if (pokemon == null)
        {
            Console.WriteLine("Ingen Pokémon å lagre.");
            return;
        }

        List<Pokemon> pokemonList = File.Exists(_filePath)
        ? JsonSerializer.Deserialize<List<Pokemon>>(File.ReadAllText(_filePath)) ?? new List<Pokemon>()
        : new List<Pokemon>();

        try
        {
            pokemonList.Add(pokemon);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(pokemonList, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine($"Lagt til {pokemon.Name} i {_filePath}");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Feil ved filhåndtering: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Uventet feil ved lagring av Pokémon: {ex.Message}");
        }
    }

    public List<Pokemon> ReadPokemonsFromFile()
    {
        if (File.Exists(_filePath))
        {
            string existingData = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(existingData))
            {
                return JsonSerializer.Deserialize<List<Pokemon>>(existingData) ?? new List<Pokemon>();
            }
        }
        return new List<Pokemon>();
    }

    public void RemovePokemonFromFile(string pokemonName)
    {
        List<Pokemon> pokemonList = ReadPokemonsFromFile();
        var pokemonToRemove = pokemonList.FirstOrDefault(p => p.Name.Equals(pokemonName, StringComparison.OrdinalIgnoreCase));

        if (pokemonToRemove != null)
        {
            pokemonList.Remove(pokemonToRemove);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(pokemonList, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine($"{pokemonName} ble fjernet fra filen.");
        }
        else
        {
            Console.WriteLine($"Fant ikke Pokémon med navn: {pokemonName}");
        }
    }

    public void DeletePokemonFile()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
            Console.WriteLine("Filen er slettet.");
        }
        else
        {
            Console.WriteLine("Filen finnes ikke.");
        }
    }

}