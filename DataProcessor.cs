using System;
using System.Threading.Tasks;

public class DataProcessor
{
    private readonly Random _random = new Random();

    public Task<(int occupied, int free)> ProcessDataAsync()
    {
        // Генерація випадкових даних для тестування
        return Task.FromResult((_random.Next(1, 100), _random.Next(1, 100)));
    }
}


