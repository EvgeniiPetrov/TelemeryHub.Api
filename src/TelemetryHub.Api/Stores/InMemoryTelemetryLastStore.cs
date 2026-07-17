using System.Collections.Concurrent;
using TelemeryHub.Api.TelemetryHub.Api.Domain;

namespace TelemeryHub.Api.TelemetryHub.Api.Stores;

public sealed class InMemoryTelemetryLastStore : ITelemetryLatestStore
{
    private readonly ConcurrentDictionary<string, TelemetryState> _state = new ();

    public void Save(TelemetryState state)
    {
        _state[state.DeviceId] = state;
    }

    public bool TryGetLatest(string deviceId, out TelemetryState? state)
    {
        return _state.TryGetValue(deviceId, out state);
    }
}