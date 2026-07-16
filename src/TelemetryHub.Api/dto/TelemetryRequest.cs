namespace TelemeryHub.Api.TelemetryHub.Api.dto;

public sealed  record TelemetryRequest(
    string DeviceId,
    double Temperature,
    double Pressure,
    string Status
    );