namespace TelemeryHub.Api.TelemetryHub.Api.Contracts;

public sealed record TelemetryAcceptedResponse(
    string Message,
    string DeviceId,
    DateTimeOffset ReceivedAt
    );