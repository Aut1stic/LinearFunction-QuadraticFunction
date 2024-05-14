using System;

public class QuadraticFunction : LinearFunction
{
    private double[,] quadraticCoefficients; // Матрица коэффициентов при парных произведениях переменных

    public QuadraticFunction(double[] coefficients, double[] bias, double[,] quadraticCoefficients) : base(coefficients, bias)
    {
        this.quadraticCoefficients = quadraticCoefficients;
    }

    // Переопределение операции сложения функций (вызовется для обоих операндов)
    public QuadraticFunction Add(QuadraticFunction other)
    {
        // Вызовется метод Add базового класса для линейных частей
        LinearFunction baseSum = base.Add(other);

        // Суммирование квадратичных коэффициентов
        int numVariables = coefficients.Length;
        double[,] newQuadraticCoefficients = new double[numVariables, numVariables];
        for (int i = 0; i < numVariables; i++)
        {
            for (int j = 0; j < numVariables; j++)
            {
                newQuadraticCoefficients[i, j] = quadraticCoefficients[i, j] + other.quadraticCoefficients[i, j];
            }
        }

        return new QuadraticFunction(baseSum.coefficients, baseSum.bias, newQuadraticCoefficients);
    }

    // Переопределение операции вычитания функций (вызовется для обоих операндов)
    public QuadraticFunction Subtract(QuadraticFunction other)
    {
        // Вызовется метод Subtract базового класса для линейных частей
        LinearFunction baseDiff = base.Subtract(other);

        // Разность квадратичных коэффициентов
        int numVariables = coefficients.Length;
        double[,] newQuadraticCoefficients = new double[numVariables, numVariables];
        for (int i = 0; i < numVariables; i++)
        {
            for (int j = 0; j < numVariables; j++)
            {
                newQuadraticCoefficients[i, j] = quadraticCoefficients[i, j] - other.quadraticCoefficients[i, j];
            }
        }

        return new QuadraticFunction(baseDiff.coefficients, baseDiff.bias, newQuadraticCoefficients);
    }

    // Переопределение операции умножения функции на число
    public new QuadraticFunction Multiply(double scalar)
    {
        // Вызовется метод Multiply базового класса для линейных частей
        LinearFunction baseProduct = base.Multiply(scalar);

        // Умножение квадратичных коэффициентов на скаляр
        int numVariables = coefficients.Length;
        double[,] newQuadraticCoefficients = new double[numVariables, numVariables];
        for (int i = 0; i < numVariables; i++)
        {
            for (int j = 0; j < numVariables; j++)
            {
                newQuadraticCoefficients[i, j] = scalar * quadraticCoefficients[i, j];
            }
        }

        return new QuadraticFunction(baseProduct.coefficients, baseProduct.bias, newQuadraticCoefficients);
    }

    // Переопределение метода ToString()
    public override string ToString()
    {
        string str = base.ToString(); // Вызовется метод базового класса

        // Добавление строки для квадратичных членов
        for (int i = 0; i < coefficients.Length; i++)
        {
            for (int j = i; j < coefficients.Length; j++)
            {
                if (quadraticCoefficients[i, j] != 0)
                {
                    str += $" + {quadraticCoefficients[i, j]:F2}x{i + 1}x{j + 1}";
                }
            }
        }

        return str;
    }

    // Метод вычисления значения функции в точке
    public new double Evaluate(double[] point)
    {
        if (point.Length != coefficients.Length)
        {
            throw new ArgumentException("Размерность точки должна совпадать с количеством переменных");
        }

        double result = base.Evaluate(point); // Вызов метода базового класса

        for (int i = 0; i < coefficients.Length; i++)
        {
            for (int j = i; j < coefficients.Length; j++)
            {
                result += quadraticCoefficients[i, j] * point[i] * point[j];
            }
        }

        return result;
    }

    // Метод получения градиента функции (вектор частных производных по каждой переменной)
    public double[] GetGradient(double[] point)
    {
        int numVariables = coefficients.Length;
        double[] gradient = new double[numVariables];

        // Градиент по линейным членам (вызовется метод базового класса)
        double[] linearGradient = base.GetGradient();
        Array.Copy(linearGradient, gradient, numVariables);

        // Добавление частных производных по квадратичным членам
        for (int i = 0; i < numVariables; i++)
        {
            for (int j = i; j < numVariables; j++)
            {
                gradient[i] += 2 * quadraticCoefficients[i, j] * point[j];
                if (i != j)
                {
                    gradient[j] += 2 * quadraticCoefficients[i, j] * point[i];
                }
            }
        }

        return gradient;
    }
}
