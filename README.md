# Blood Pressure Tracker

A Blazor WebAssembly application for tracking blood pressure readings over a 10-week period.

## Features

- **Simple Data Entry**: Easy-to-use form with large buttons and inputs, perfect for senior adults
- **Local Storage**: All data is stored locally in your browser using localStorage (no server required)
- **History View**: Review all your blood pressure readings with averages and statistics
- **Print-Friendly Format**: Print your readings in the doctor's preferred 10-week grid format
- **No Login Required**: Single-user app with no authentication needed

## How to Use

### Running the Application

1. Make sure you have .NET 10.0 SDK installed
2. Navigate to the project directory
3. Run the application:
   ```bash
   dotnet run
   ```
4. Open your browser and navigate to the URL shown (typically `http://localhost:5000`)

### Recording Blood Pressure

1. Navigate to the **Entry** page (home page)
2. Select the date for your reading
3. Choose the time of day (Morning, Midday, or Evening)
4. Enter your systolic (top) number
5. Enter your diastolic (bottom) number
6. Optionally add any notes
7. Click **Save Reading**

### Viewing History

1. Navigate to the **History** page
2. View all your readings in a table format
3. See average systolic and diastolic values
4. Delete individual readings if needed
5. Clear all data if you want to start fresh

### Printing Your Records

1. Navigate to the **Print View** page
2. Select the start date for your 10-week tracking period
3. Review the grid showing all 10 weeks with Sunday-Saturday for each week
4. Each day shows Morning, Midday, and Evening readings
5. Click **Print** to print the report

## Doctor's Instructions

Check your blood pressure at least three times a week, but at different times of the day:
- One reading in the morning
- One reading in the afternoon (midday)
- One reading in the evening

## Data Storage

All data is stored locally in your browser's localStorage. This means:
- ✅ Your data never leaves your device
- ✅ No internet connection required after initial load
- ✅ Complete privacy
- ⚠️ Data is specific to this browser on this device
- ⚠️ Clearing browser data will delete your readings
- ⚠️ Switching browsers or devices will not carry over your data

## Project Structure

```
BloodPressureTracker/
├── Models/
│   └── BloodPressureReading.cs    # Data model
├── Services/
│   └── BloodPressureService.cs    # Data service with localStorage
├── Pages/
│   ├── Home.razor                 # Data entry form
│   ├── History.razor              # History view
│   └── Print.razor                # Print-friendly view
├── Layout/
│   ├── MainLayout.razor           # Main layout
│   └── NavMenu.razor              # Navigation menu
└── wwwroot/
    └── css/
        └── custom.css             # Custom styling
```

## Technology Stack

- **Blazor WebAssembly**: Frontend framework
- **C# / .NET 10.0**: Programming language and runtime
- **localStorage**: Client-side data persistence
- **Bootstrap 5**: CSS framework
- **Custom CSS**: Senior-friendly large fonts and buttons

## Browser Compatibility

Works with modern browsers that support WebAssembly:
- Chrome/Edge (recommended)
- Firefox
- Safari

## Future Enhancements

Potential features for future versions:
- Export data to CSV/PDF
- Data backup/restore functionality
- Medication tracking
- Blood pressure trends and charts
- Multiple user profiles
- Mobile app version

## License

This is a personal health tracking application. Use at your own discretion.
