using System;
using System.Timers;
using System.Windows;

namespace ParkingMonitoring
{
    public partial class MainWindow : Window
    {
        private const int TotalParkingSpaces = 100; // Загальна кількість місць на парковці
        private int _occupiedSpaces = 0; // Зайняті місця
        private readonly Logger _logger = new Logger();
        private readonly Random _random = new Random(); // Для симуляції даних із сенсорів
        private readonly Timer _timer = new Timer(1000); // Таймер на 1 секунду

        public MainWindow()
        {
            InitializeComponent(); // Підключення XAML
            _timer.Elapsed += UpdateParkingData;
            _timer.Start();
        }

        private void UpdateParkingData(object sender, ElapsedEventArgs e)
        {
            // Генерація даних: випадкова кількість зайнятих місць
            _occupiedSpaces = _random.Next(0, TotalParkingSpaces + 1);
            int freeSpaces = TotalParkingSpaces - _occupiedSpaces;
            int occupancyPercentage = (_occupiedSpaces * 100) / TotalParkingSpaces;

            // Оновлення UI через Dispatcher
            Dispatcher.Invoke(() =>
            {
                ParkingProgressBar.Value = occupancyPercentage;
                OccupancyText.Text = $"Заповнено: {_occupiedSpaces}, Вільно: {freeSpaces}";

                if (occupancyPercentage > 90)
                {
                    _logger.Log("Парковка заповнена більше ніж на 90%!");
                }

                LogListBox.ItemsSource = _logger.GetLogs();
            });
        }
    }
}
