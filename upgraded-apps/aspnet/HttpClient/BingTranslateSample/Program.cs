using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

// Environment variables for configuration
var key = Environment.GetEnvironmentVariable("TRANSLATOR_KEY");
var endpoint = Environment.GetEnvironmentVariable("TRANSLATOR_ENDPOINT")
              ?? "https://api.cognitive.microsofttranslator.com";
var region = Environment.GetEnvironmentVariable("TRANSLATOR_REGION");

if (string.IsNullOrWhiteSpace(key))
{
    Console.Error.WriteLine("Missing TRANSLATOR_KEY env var.");
    return;
}

// Get input from command line args or prompt user
string inputText, from, to;

if (args.Length >= 3)
{
    inputText = args[0];
    from = args[1];
    to = args[2];
}
else
{
    Console.Write("Text: ");
    inputText = Console.ReadLine() ?? "";

    Console.Write("From (e.g. en): ");
    from = Console.ReadLine() ?? "";

    Console.Write("To (e.g. ja): ");
    to = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(inputText) ||
        string.IsNullOrWhiteSpace(from) ||
        string.IsNullOrWhiteSpace(to))
    {
        Console.Error.WriteLine("Missing required inputs.");
        Environment.Exit(1);
    }
}

var uri = $"{endpoint.TrimEnd('/')}/translate?api-version=3.0&from={Uri.EscapeDataString(from)}&to={Uri.EscapeDataString(to)}";

using var http = new HttpClient();
http.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

// Region header is required for some resource types.
if (!string.IsNullOrWhiteSpace(region))
    http.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", region);

var requestBody = new object[]
{
    new { Text = inputText }
};

using var content = new StringContent(
    JsonSerializer.Serialize(requestBody),
    Encoding.UTF8,
    "application/json"
);

using var response = await http.PostAsync(uri, content);

var responseText = await response.Content.ReadAsStringAsync();
if (!response.IsSuccessStatusCode)
{
    Console.Error.WriteLine($"HTTP {(int)response.StatusCode} {response.ReasonPhrase}");
    Console.Error.WriteLine(responseText);
    return;
}

// Response shape: array of results; each has translations array.
using var doc = JsonDocument.Parse(responseText);
var root = doc.RootElement;

if (root.ValueKind != JsonValueKind.Array || root.GetArrayLength() == 0)
{
    Console.WriteLine("Unexpected response:");
    Console.WriteLine(responseText);
    return;
}

var translations = root[0].GetProperty("translations");
foreach (var t in translations.EnumerateArray())
{
    var lang = t.GetProperty("to").GetString();
    var translatedText = t.GetProperty("text").GetString();
    Console.WriteLine($"{lang}: {translatedText}");
}
