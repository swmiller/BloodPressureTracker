using Microsoft.JSInterop;

namespace BloodPressureTracker.Services;

public static class JSInterop
{
    public static async Task<bool> ConfirmAsync(string message)
    {
        // This will be injected via the component
        return await Task.FromResult(true); // Placeholder
    }
}
