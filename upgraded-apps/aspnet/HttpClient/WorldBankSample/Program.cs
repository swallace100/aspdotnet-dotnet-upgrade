using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorldBankSample
{
    /// <summary>
    /// Sample download list of countries from the World Bank Data sources at http://data.worldbank.org/
    /// </summary>
    class Program
    {
        private static string _address = "http://api.worldbank.org/countries?format=json";

        private static async Task RunClient()
        {
            // Create an HttpClient instance
            using var client = new HttpClient();

            // Send a request asynchronously and continue when complete
            HttpResponseMessage response = await client.GetAsync(_address);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read response asynchronously as JSON and write out top facts for each country
            string jsonContent = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(jsonContent);
            
            JsonElement root = doc.RootElement;
            JsonElement countries = root[1];

            Console.WriteLine("First 50 countries listed by The World Bank...");
            foreach (var country in countries.EnumerateArray())
            {
                Console.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
                    GetJsonString(country, "name"),
                    GetJsonString(country, "iso2Code"),
                    GetJsonString(country, "capitalCity"),
                    GetJsonString(country, "latitude"),
                    GetJsonString(country, "longitude"));
            }
        }

        private static string GetJsonString(JsonElement element, string propertyName)
        {
            if (element.TryGetProperty(propertyName, out var value) && value.ValueKind != JsonValueKind.Null)
            {
                return value.GetString() ?? string.Empty;
            }
            return string.Empty;
        }

        static async Task Main(string[] args)
        {
            await RunClient();

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
    }
}
