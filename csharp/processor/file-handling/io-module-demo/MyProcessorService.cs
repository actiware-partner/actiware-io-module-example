using Development.SDK.Module.Feature.Processor.Interfaces;
using Development.SDK.Module.Feature.Processor.Domain.Infrastructure;
using Development.SDK.Module.Feature.Common.Domain.Container;
using System.IO;

public class MyProcessorService : IProcessorService
{
    // 1. Ausführung: Datei erzeugen und Metadaten speichern
    public async Task<Step> ExecuteAsync(ProcessorExecuteSettings executeSettings)
    {
        // Beispiel: Eine Datei wird erzeugt und ihr Pfad gespeichert
        var filePath = "/tmp/myfile.txt";
        await File.WriteAllTextAsync(filePath, "Beispielinhalt");

        // Metadaten für die Datei anlegen
        var objectItem = new ObjectItem
        {
            Name = "myfile.txt",
            DownloadAttributes = new Dictionary<string, object>
            {
                { "path", filePath },
                { "customId", "12345" }
            }
        };

        // Das Step-Objekt enthält alle erzeugten/verarbeiteten Dateien
        return new Step
        {
            Objects = new List<ObjectItem> { objectItem }
        };
    }

    // 2. Download: Datei anhand der Attribute bereitstellen
    public async Task<Stream?> DownloadAsync(ProcessorDownloadSettings executeSettings)
    {
        // Der Pfad zur Datei wird aus den Attributen gelesen
        var path = executeSettings.Attributes["path"]?.ToString();
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            // Datei als Stream zurückgeben (wird vom SDK an den Client gesendet)
            return File.OpenRead(path);
        }
        // Falls die Datei nicht existiert, null zurückgeben
        return null;
    }

    // 3. Cleanup: Datei nach Verarbeitung löschen
    public async Task<StepCleanup?> CleanupAsync(ProcessorCleanupSettings cleanupSettings)
    {
        // Den Pfad aus den Metadaten extrahieren
        var path = cleanupSettings.Step?.Objects?.FirstOrDefault()?.DownloadAttributes?["path"]?.ToString();
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            File.Delete(path);
        }
        // Rückmeldung, dass das Aufräumen erfolgreich war
        return new StepCleanup { Success = true };
    }
}