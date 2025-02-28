using System;
using System.Security;
using System.Threading.Tasks;

namespace filbehandling_og_jasonserializer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClientController = new HttpClientController();

            while (true)
            {
                Console.WriteLine("Velg en handling:");
                Console.WriteLine("1. Hent Pokémon data:");
                Console.WriteLine("2. Les alle Pokémon fra fil:");
                Console.WriteLine("3. Fjern Pokémon fra fil:");
                Console.WriteLine("4. Slett hele Pokémon-fil:");
                Console.WriteLine("5. Avslutt:");

                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    Console.WriteLine("Avslutter...");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Console.Write("Skriv navnet på en Pokémon: ");
                        string pokemonName = Console.ReadLine();
                        Pokemon? pokemon = await httpClientController.FetchPokemonData(pokemonName);

                        if (pokemon != null)
                        {
                            Console.WriteLine("\nPokémon Info:");
                            Console.WriteLine(pokemon);

                            httpClientController.SavePokemonToFile(pokemon);
                        }
                        else
                        {
                            Console.WriteLine("Kunne ikke hente Pokémon-data");
                        }
                        break;

                    case "2":
                        var pokemons = httpClientController.ReadPokemonsFromFile();
                        if (pokemons.Count == 0)
                        {
                            Console.WriteLine("Ingen Pokémon lagret.");
                        }
                        else
                        {
                            Console.WriteLine("Leste Pokémon fra fil:");
                            foreach (var p in pokemons)
                            {
                                Console.WriteLine(p);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Skriv inn navnet på Pokémon du vil fjerne: ");
                        string removeName = Console.ReadLine();
                        httpClientController.RemovePokemonFromFile(removeName);
                        break;

                    case "4":
                        httpClientController.DeletePokemonFile();
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg, prøv igjen.");
                        break;
                }
            }
        }
    }
}

