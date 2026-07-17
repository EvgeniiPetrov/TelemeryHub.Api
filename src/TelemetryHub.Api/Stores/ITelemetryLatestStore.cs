using TelemeryHub.Api.TelemetryHub.Api.Domain;

namespace TelemeryHub.Api.TelemetryHub.Api.Stores;

public interface ITelemetryLatestStore
{
    void Save(TelemetryState state);
    bool TryGetLatest(string deviceId, out TelemetryState? state);
}