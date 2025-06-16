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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/v1/processor/execute", ([FromBody] ProcessorExecuteRequest request) =>
{
    using var helper = new Development.SDK.Module.Feature.Common.Controller.Helper(request.Container);

    var step = new Development.SDK.Module.Feature.Common.Domain.Container.Step();
    step.Messages = helper.Messages;

    helper.AddMessage(Development.SDK.Module.Feature.Common.Enums.ReportLevel.Message, string.Empty, "Prozessor aufgerufen via Input-Port: {Port}", request.InputPort);

    step.State = Development.SDK.Module.Feature.Common.Enums.ProcessState.Done;

    step.ExitPort = "output";

    return Results.Ok(step);
})
.Produces<Development.SDK.Module.Feature.Common.Domain.Container.Step>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status500InternalServerError);

app.UseCors();

app.Run();