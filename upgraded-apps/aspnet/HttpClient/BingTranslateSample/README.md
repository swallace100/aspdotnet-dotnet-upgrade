### Bing Translate Sample

## Environment Variables setup

Run the following code to set the environment variables.

```PowerShell
$env:TRANSLATOR_KEY = "your key"
$env:TRANSLATOR_ENDPOINT = "https://api.cognitive.microsofttranslator.com"
$env:TRANSLATOR_REGION = "<your-region>"

```

## Run the app

Below is an example command to convert English text into Japanese

```PowerShell
dotnet run -- "Good morning" en ja
```

## Developer Notes

This application had to be recreated from scratch because Bing's Translator V2 was retired and Translator V3 uses JSON REST APIs.

There was also a complicated Nuget and packages definition setup in the original version, which isn't necessary in .NET 10.
