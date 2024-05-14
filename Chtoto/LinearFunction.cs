using System;
using System.Linq;

public class LinearFunction
{
    public double[] coefficients; // Коэффициенты при переменных
    public double[] bias; // Свободный член

    public LinearFunction(double[] coefficients, double[] bias)
    {
        this.coefficients = coefficients;
        this.bias = bias;
    }

    // Операция сложения функций
    public LinearFunction Add(LinearFunction other)
    {
        if (coefficients.Length != other.coefficients.Length)
        {
            throw new ArgumentException("Размеры коэффициентов должны совпадать");
        }

        double[] newCoefficients = new double[coefficients.Length];
        double[] newBias = new double[bias.Length];

        for (int i = 0; i < coefficients.Length; i++)
        {
            newCoefficients[i] = coefficients[i] + other.coefficients[i];
            newBias[i] = bias[i] + other.bias[i];
        }

        return new LinearFunction(newCoefficients, newBias);
    }

    // Операция вычитания функций
    public LinearFunction Subtract(LinearFunction other)
    {
        if (coefficients.Length != other.coefficients.Length)
        {
            throw new ArgumentException("Размеры коэффициентов должны совпадать");
        }

        double[] newCoefficients = new double[coefficients.Length];
        double[] newBias = new double[bias.Length];

        for (int i = 0; i < coefficients.Length; i++)
        {
            newCoefficients[i] = coefficients[i] - other.coefficients[i];
            newBias[i] = bias[i] - other.bias[i];
        }

        return new LinearFunction(newCoefficients, newBias);
    }

    // Операция умножения функции на число
    public LinearFunction Multiply(double scalar)
    {
        double[] newCoefficients = new double[coefficients.Length];
        double[] newBias = new double[bias.Length];

        for (int i = 0; i < coefficients.Length; i++)
        {
            newCoefficients[i] = scalar * coefficients[i];
            newBias[i] = scalar * bias[i];
        }

        return new LinearFunction(newCoefficients, newBias);
    }

    // Переопределение операции преобразования в строку
    public override string ToString()
    {
        string str = "";

        for (int i = 0; i < coefficients.Length; i++)
        {
            if (coefficients[i] != 0)
            {
                str += $"{coefficients[i]:F2}x{i + 1}";

                if (bias[i] != 0)
                {
                    str += (bias[i] > 0) ? "+" : "-";
                    str += $"{Math.Abs(bias[i]):F2}";
                }
            }
            else if (bias[i] != 0)
            {
                str += $"{bias[i]:F2}";
            }

            if (i < coefficients.Length - 1)
            {
                str += " + ";
            }
        }

        return str;
    }

    // Статический метод Parse() для создания объекта из строки
    public static LinearFunction Parse(string str)
    {
        string[] parts = str.Split(' ');

        int numVariables = parts.Length / 2; // Количество переменных
        double[] coefficients = new double[numVariables];
        double[] bias = new double[numVariables];

        for (int i = 0; i < parts.Length; i++)
        {
            if (i % 2 == 0)
            {
                // Коэффициент при переменной
                int variableIndex = i / 2;
                string coefficientStr = parts[i].Trim('x');

                if (coefficientStr.Contains("+"))
                {
                    coefficientStr = coefficientStr.Substring(1);
                }

                coefficients[variableIndex] = double.Parse(coefficientStr);
            }
            else
            {
                // Свободный член
                int variableIndex = (i - 1) / 2;
                string biasStr = parts[i].Trim();

                bias[variableIndex] = double.Parse(biasStr);
            }
        }

        return new LinearFunction(coefficients, bias);
    }

    // Метод вычисления значения функции в точке
    public double Evaluate(double[] point)
    {
        if (point.Length != coefficients.Length)
        {
            throw new ArgumentException("Размерность точки должна совпадать с количеством переменных");
        }

        double result = 0;
        for (int i = 0; i < coefficients.Length; i++)
        {
            result += coefficients[i] * point[i];
        }

        return result + bias.Sum(); // Суммирование свободных членов
    }

    // Метод получения градиента функции (массив производных по каждой переменной)
    public double[] GetGradient()
    {
        return coefficients; // Градиент линейной функции равен вектору коэффициентов
    }
}