namespace BloodPressureTracker.Models;

public class BloodPressureReading
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.Today;
    public TimeOfDay TimeOfDay { get; set; }
    public int? Systolic { get; set; }
    public int? Diastolic { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public enum TimeOfDay
{
    Morning,
    Midday,
    Evening
}
