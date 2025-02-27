using System;
using System.Security;
using System.Threading.Tasks;

namespace filbehandling_og_jasonserializer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = "https://pokeapi.co/api/v2/";
            string jsonFilePath = "pokemon.json";

            var apiClient = new HttpClientController();

            string jsonData = await apiClient.FetchDataFromApi(apiUrl);
            apiClient.SaveDataToFile(jsonData, jsonFilePath);
        }


    }
}

