using System;
using System.Threading.Tasks;

public class SensorSimulator
{
    private readonly Random _random = new Random();
    public Task<int> GetSensorDataAsync()
    {
        return Task.Run(() => _random.Next(0, 2)); // 0 - вільне місце, 1 - зайняте.
    }
}
