using System.Collections.Concurrent;
using TelemeryHub.Api.TelemetryHub.Api.dto;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var latestState = new ConcurrentDictionary<string, TelemetryState>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Time = DateTimeOffset.UtcNow
}));

app.MapGet("/ping", () => Results.Ok(new 
{
    Message = "pong"
}));

app.MapGet("/api/devices/{id}/latest", (string id) =>
{
    if (latestState.TryGetValue(id, out var value))
    {
        return Results.Ok(value);
    }

    return Results.NotFound(new
    {
        Error = "Device not found",
        DeviceId = id
    });
});

app.MapPost("/api/telemetry", (TelemetryRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.DeviceId))
    {
        return Results.BadRequest(new { Error = "DeviceId is required" });
    }

    if (request.Temperature < -100 || request.Temperature > 200)
    {
        return Results.BadRequest(new { Error = "Temperature is out of allowed range" });
    }

    if (request.Pressure < 0 || request.Pressure > 100)
    {
        return Results.BadRequest(new { Error = "Pressure is out of allowed range" });
    }

    if (string.IsNullOrWhiteSpace(request.Status))
    {
        return Results.BadRequest(new { Error = "Status is required" });
    }

    var state = new TelemetryState(
        request.DeviceId,
        request.Temperature,
        request.Pressure,
        request.Status,
        DateTimeOffset.UtcNow
        );
    
    latestState[request.DeviceId] = state;
    
    return Results.Accepted(value: new
    {
        Message = "Telemetry accepted",
        PumpStationDeviceId = request.DeviceId,
        ReceivedAt = DateTimeOffset.UtcNow
    });

});
app.Run();