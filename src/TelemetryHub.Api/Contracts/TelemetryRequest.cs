namespace TelemeryHub.Api.TelemetryHub.Api.Contracts;

public sealed  record TelemetryRequest(
    string DeviceId,
    double Temperature,
    double Pressure,
    string Status
    );