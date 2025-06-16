using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// CORS Policy aktivieren (z.B. für lokale Entwicklung)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/plugins/format/to-upper", ([FromBody] PluginExecuteRequest? request, ILogger<Program> logger) =>
{
    try
    {
        logger.LogInformation("Format-Funktion aufgerufen mit Wert: {Value}", request?.Value);
        // Eingabevalidierung
        if (request == null)
        {
            logger.LogWarning("Request ist null");
            return Results.BadRequest("Request darf nicht null sein");
        }
        if (string.IsNullOrEmpty(request.Value))
        {
            logger.LogInformation("Leerer Wert empfangen, gebe leeren String zurück");
            return Results.Ok(string.Empty);
        }
        // Formatierung durchführen
        var result = request.Value.ToUpper();
        logger.LogInformation("Formatierung erfolgreich: '{Original}' -> '{Formatted}'", request.Value, result);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Fehler bei der Formatierung von: {Value}", request?.Value);
        return Results.Problem("Ein unerwarteter Fehler ist aufgetreten");
    }
})
.WithName("FormatToUpper")
.Produces<string>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status500InternalServerError);

app.UseCors();

app.Run();