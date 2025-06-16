# ACTIWARE.IO Beispielprojekte – Modul mit Prozessor und Formatierungsfunktionen

Dies ist eine Sammlung von Beispielprojekten für die Entwicklung von Modulen für ACTIWARE.IO. Die Projekte zeigen, wie man einen Prozessor und/oder Formatierungsfunktionen implementiert.

Weitere Informationen zur Entwicklung von Modulen und zur Nutzung des Software Development Kits (SDK) finden Sie in der offiziellen Dokumentation:

[ACTIWARE.IO SDK Dokumentation](https://actiware-development.atlassian.net/wiki/spaces/AWIO/pages/946733388/Software+Development+Kit)

## Projektstruktur

- `csharp/processor/` – Beispielprojekte für Prozessor-Module
- `csharp/plugins/format/` – Beispielprojekte für Formatierungsfunktionen

Jedes Unterverzeichnis enthält ein eigenständiges Beispielprojekt mit Quellcode, Konfiguration und Startdateien.

## Voraussetzungen

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Vorbereitung

1. Repository klonen oder herunterladen.
2. In das gewünschte Projektverzeichnis wechseln, z.B. für ein Prozessor-Beispiel:
   ```zsh
   cd csharp/processor/simple/io-module-demo
   ```

## Build und Start

1. Projekt bauen:
   ```zsh
   dotnet build
   ```
2. Projekt starten:
   ```zsh
   dotnet run
   ```

Das Modul kann nun lokal getestet werden. Die API ist standardmäßig unter `https://localhost:5001` erreichbar (bei Web API Projekten).

## Hinweise

- Weitere Controller, Services oder Formatierungsfunktionen können in den jeweiligen Projekten ergänzt werden.
- Für die Entwicklung empfiehlt sich die Nutzung von Swagger (bei Web API Projekten automatisch aktiviert im Development-Modus).
- Für weiterführende Informationen und Integrationshinweise besuchen Sie bitte die [offizielle SDK-Dokumentation](https://actiware-development.atlassian.net/wiki/spaces/AWIO/pages/946733388/Software+Development+Kit).

---

Diese Projekte dienen als Ausgangspunkt für eigene ACTIWARE.IO Modul-Entwicklungen.
