namespace TelemeryHub.Api.TelemetryHub.Api.Domain;

public sealed record TelemetryState(
        string DeviceId,
        double Temperature,
        double Pressure,
        string Status,
        DateTimeOffset ReceivedAt
    );