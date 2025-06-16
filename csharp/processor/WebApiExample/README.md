# WebApiExample

Dies ist ein einfaches C# Web API Projekt, erstellt mit dem .NET CLI-Befehl `dotnet new webapi`.

## Projektstruktur

- **Controllers/**: Enthält die API-Controller für die Endpunkte.
- **Program.cs**: Einstiegspunkt der Anwendung.
- **appsettings.json**: Konfigurationsdatei für die Anwendung.

## Voraussetzungen

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Build und Start

Im Projektverzeichnis (`csharp/processor/WebApiExample`) ausführen:

```zsh
dotnet build
dotnet run
```

Die API ist dann standardmäßig unter `https://localhost:5001` erreichbar.

## Beispiel-Endpunkt

```http
GET /weatherforecast
```

Antwort:
```json
[
  {
    "date": "2025-06-16T00:00:00Z",
    "temperatureC": 25,
    "temperatureF": 77,
    "summary": "Warm"
  }
]
```

## Hinweise

- Weitere Controller und Endpunkte können im Ordner `Controllers` hinzugefügt werden.
- Für die Entwicklung empfiehlt sich die Nutzung von Swagger (automatisch aktiviert im Development-Modus).
