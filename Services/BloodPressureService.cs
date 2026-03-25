using System.Text.Json;
using BloodPressureTracker.Models;
using Microsoft.JSInterop;

namespace BloodPressureTracker.Services;

public class BloodPressureService
{
    private const string StorageKey = "bloodPressureData";
    private readonly IJSRuntime _jsRuntime;
    private List<BloodPressureReading> _readings = new();

    public BloodPressureService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        await LoadDataAsync();
    }

    public async Task<List<BloodPressureReading>> GetAllReadingsAsync()
    {
        if (_readings == null || _readings.Count == 0)
        {
            await LoadDataAsync();
        }
        return _readings.OrderBy(r => r.Date).ThenBy(r => r.TimeOfDay).ToList();
    }

    public async Task<BloodPressureReading?> GetReadingByIdAsync(Guid id)
    {
        if (_readings == null || _readings.Count == 0)
        {
            await LoadDataAsync();
        }
        return _readings.FirstOrDefault(r => r.Id == id);
    }

    public async Task<BloodPressureReading?> GetReadingAsync(DateTime date, TimeOfDay timeOfDay)
    {
        if (_readings == null || _readings.Count == 0)
        {
            await LoadDataAsync();
        }
        return _readings.FirstOrDefault(r => r.Date.Date == date.Date && r.TimeOfDay == timeOfDay);
    }

    public async Task AddReadingAsync(BloodPressureReading reading)
    {
        // Check if a reading already exists for this date and time
        var existing = await GetReadingAsync(reading.Date, reading.TimeOfDay);
        if (existing != null)
        {
            // Update existing reading
            existing.Systolic = reading.Systolic;
            existing.Diastolic = reading.Diastolic;
            existing.Notes = reading.Notes;
        }
        else
        {
            _readings.Add(reading);
        }
        await SaveDataAsync();
    }

    public async Task UpdateReadingAsync(BloodPressureReading reading)
    {
        var existing = _readings.FirstOrDefault(r => r.Id == reading.Id);
        if (existing != null)
        {
            existing.Date = reading.Date;
            existing.TimeOfDay = reading.TimeOfDay;
            existing.Systolic = reading.Systolic;
            existing.Diastolic = reading.Diastolic;
            existing.Notes = reading.Notes;
            await SaveDataAsync();
        }
    }

    public async Task DeleteReadingAsync(Guid id)
    {
        var reading = _readings.FirstOrDefault(r => r.Id == id);
        if (reading != null)
        {
            _readings.Remove(reading);
            await SaveDataAsync();
        }
    }

    public async Task<List<BloodPressureReading>> GetReadingsForWeekAsync(DateTime startDate)
    {
        if (_readings == null || _readings.Count == 0)
        {
            await LoadDataAsync();
        }

        var endDate = startDate.AddDays(7);
        return _readings
            .Where(r => r.Date >= startDate && r.Date < endDate)
            .OrderBy(r => r.Date)
            .ThenBy(r => r.TimeOfDay)
            .ToList();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            if (!string.IsNullOrEmpty(json))
            {
                _readings = JsonSerializer.Deserialize<List<BloodPressureReading>>(json) ?? new List<BloodPressureReading>();
            }
            else
            {
                _readings = new List<BloodPressureReading>();
            }
        }
        catch
        {
            _readings = new List<BloodPressureReading>();
        }
    }

    private async Task SaveDataAsync()
    {
        var json = JsonSerializer.Serialize(_readings);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }

    public async Task ClearAllDataAsync()
    {
        _readings.Clear();
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", StorageKey);
    }
}
