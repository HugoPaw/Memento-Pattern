using System;
using System.Collections.Generic;

// Interface für alle Beobachter
public interface IDisplay
{
    void Update(float temperature);
}

// Das Subject
public class WeatherStation
{
    private List<IDisplay> _displays = new List<IDisplay>();
    private float _temperature;

    public void AddObserver(IDisplay display)
    {
        _displays.Add(display);
    }

    public void RemoveObserver(IDisplay display)
    {
        _displays.Remove(display);
    }

    public void SetTemperature(float temperature)
    {
        _temperature = temperature;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var display in _displays)
        {
            display.Update(_temperature);
        }
    }
}

// Konkrete Beobachter
public class PhoneDisplay : IDisplay
{
    public void Update(float temperature)
    {
        Console.WriteLine($"[PhoneDisplay] Neue Temperatur: {temperature}°C");
    }
}

public class WindowDisplay : IDisplay
{
    public void Update(float temperature)
    {
        Console.WriteLine($"[WindowDisplay] Neue Temperatur: {temperature}°C");
    }
}
