using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Пример создания и работы с линейными функциями
        double[] coefficients1 = { 2.0, -3.0, 1.0 };
        double[] bias1 = { 4.0, 2.0, -1.0 };
        LinearFunction f1 = new LinearFunction(coefficients1, bias1);

        Console.WriteLine("Линейная функция f1:");
        Console.WriteLine(f1.ToString()); // Вывод f1 в строку

        double[] point1 = { 1.5, -2.0, 0.5 };
        double value1 = f1.Evaluate(point1); // Вычисление значения f1 в точке
        Console.WriteLine($"f1({point1[0]}, {point1[1]}, {point1[2]}) = {value1}");

        double[] coefficients2 = { -1.0, 0.5, 2.0 };
        double[] bias2 = { 0.0, 1.0, 0.5 };
        LinearFunction f2 = new LinearFunction(coefficients2, bias2);

        LinearFunction f3 = f1.Add(f2); // Сложение f1 и f2
        Console.WriteLine("\nf1 + f2:");
        Console.WriteLine(f3.ToString());

        LinearFunction f4 = f1.Subtract(f2); // Вычитание f1 и f2
        Console.WriteLine("\nf1 - f2:");
        Console.WriteLine(f4.ToString());

        double scalar = 3.0;
        LinearFunction f5 = f1.Multiply(scalar); // Умножение f1 на скаляр
        Console.WriteLine("\n3 * f1:");
        Console.WriteLine(f5.ToString());

        // Пример создания и работы с квадратичными функциями
        double[,] quadraticCoefficients1 = {
            { 1.0, 0.5, -0.2 },
            { 0.5, 2.0, 1.0 },
            { -0.2, 1.0, 3.0 }
        };
        QuadraticFunction qf1 = new QuadraticFunction(coefficients1, bias1, quadraticCoefficients1);

        Console.WriteLine("\n\nКвадратичная функция qf1:");
        Console.WriteLine(qf1.ToString());

        double value2 = qf1.Evaluate(point1); // Вычисление значения qf1 в точке
        Console.WriteLine($"qf1({point1[0]}, {point1[1]}, {point1[2]}) = {value2}");

        double[,] quadraticCoefficients2 = {
            { -2.0, 1.5, 0.0 },
            { 1.5, -1.0, -0.5 },
            { 0.0, -0.5, 2.0 }
        };
        QuadraticFunction qf2 = new QuadraticFunction(coefficients2, bias2, quadraticCoefficients2);

        QuadraticFunction qf3 = qf1.Add(qf2); // Сложение qf1 и qf2
        Console.WriteLine("\nqf1 + qf2:");
        Console.WriteLine(qf3.ToString());

        QuadraticFunction qf4 = qf1.Subtract(qf2); // Вычитание qf1 и qf2
        Console.WriteLine("\nqf1 - qf2:");
        Console.WriteLine(qf4.ToString());

        scalar = 2.0;
        QuadraticFunction qf5 = qf1.Multiply(scalar); // Умножение qf1 на скаляр
        Console.WriteLine("\n2 * qf1:");
        Console.WriteLine(qf5.ToString());

        // Вычисление градиента qf1
        double[] gradient1 = qf1.GetGradient();
        Console.WriteLine("\nГрадиент qf1:");
        for (int i = 0; i < gradient1.Length; i++)
        {
            Console.Write($"{gradient1[i]:F2} ");
        }
    }
}
