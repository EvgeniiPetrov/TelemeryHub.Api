namespace TelemeryHub.Api.TelemetryHub.Api.dto;

public sealed record TelemetryState(
        string DeviceId,
        double Temperature,
        double Pressure,
        string Status,
        DateTimeOffset ReceivedAt
    );