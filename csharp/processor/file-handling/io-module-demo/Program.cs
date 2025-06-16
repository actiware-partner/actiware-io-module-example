using Microsoft.AspNetCore.Mvc;
using Development.SDK.Module.Feature.Processor.Http;

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

builder.Services.AddScoped<IProcessorService, MyProcessorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors();

app.Run();