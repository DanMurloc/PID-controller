// Создание ПИД-регулятора с заданными коэффициентами
using PID;
using ScottPlot;
using System.Diagnostics;
PIDController pid = new PIDController(1.0, 0.1, 0.01);

// Установка заданного значения (например, целевая температура)
pid.SetSetPoint(90.0);

// Пример использования в цикле управления
double actualValue = 100.0; // Текущее значение
double deltaTime = 1.0; // Время, прошедшее с последнего вычисления (например, 1 секунда)
List<double> pointsX = new List<double>();
List<double> pointsY = new List<double>();
for (int i = 0; i < 200; i++)
{
    // Вычисление управляющего воздействия
    double controlSignal = pid.Compute(actualValue, deltaTime);

    // Обновление текущего значения (например, под действием управляющего сигнала)
    actualValue += controlSignal * deltaTime; // Это пример, в реальной системе будет зависеть от характеристик системы
    pointsX.Add(actualValue);
    pointsY.Add(i);
    // Вывод текущего значения для наблюдения
    Console.WriteLine($"Current Value: {actualValue}");
}

// Данные для графика
double[] dataX = pointsY.ToArray();
double[] dataY = pointsX.ToArray();

// Создание нового графика
var plt = new ScottPlot.Plot();
// Добавление данных на график
var scatterPlot = plt.Add.Scatter(dataX, dataY);
scatterPlot.MarkerSize = 10;
scatterPlot.LineWidth = 0;
// Настройка заголовков
plt.Title("График");
plt.XLabel("Время, t");
plt.YLabel("Значение");

// Сохранение графика в файл
plt.SavePng("plot.png",1400,900);
// Открытие графика с помощью системного приложения
Process.Start(new ProcessStartInfo("plot.png") { UseShellExecute = true });
Console.WriteLine("График сохранен в файл plot.png");
