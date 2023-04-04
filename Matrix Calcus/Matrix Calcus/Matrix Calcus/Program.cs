using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Данный класс предназначен для выполнения различных операций с матрицами.
/// </summary>
class Program
{
    static Random random = new Random();
    static int number, n, m, n1, n2, m1, m2;
    static string n0, m0;
    static double[,] matrixFirst;
    static double[,] matrixSecond;
    static string[] str, str1, str2;
    /// <summary>
    /// Метод CheckNumber проверяет корректность номера желаемой операции над матрицей/ами.
    /// </summary>
    static void CheckNumber(out int number)
    {
        string num;
        int flag = 0;
        do
        {
            Console.Write("Введите номер желаемой операции(целое число от 1 до 7):");
            num = Console.ReadLine();
            if (!int.TryParse(num, out number) | (number < 1) | (number > 7))
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
    }

    /// <summary>
    /// Метод WhatISNumber реализует вызов методов в зависимоти от того, какую операцию над матрицей/ами хочет совершить пользователь.
    /// </summary>
    static void WhatISNumber(int number)
    {
        if (number == 1)
        {
            // Нахождение следа матрицы.
            MatrixTrace();
        }
        if (number == 2)
        {
            // Транспонирование матрицы.
            MatrixTransposition();
        }
        if (number == 3)
        {
            //Сумма двух матриц.
            MatrixSum();
        }
        if (number == 4)
        {
            // Вычитание матриц.
            MatrixSubtraction();
        }
        if (number == 5)
        {
            // Произведение матриц.
            MatrixMultiplication();
        }
        if (number == 6)
        {
            // Умножение матрицы на число
            MatrixMultiNum();
        }
        if (number == 7)
        {
            // Нахождение определителя матрицы.
            MatrixDeterminant();
        }
    }

    /// <summary>
    /// Метод InputInstruction реализует вызов методов, в зависимости от того, как пользователь хочет сгенерировать матрицу/ы.
    /// </summary>
    static void InputInstruction(in int NumberOfMatrix)
    {
        Console.WriteLine();
        Console.WriteLine("Для выполнения операции вам понадобится матрица. Вы можете выбрать три варинта её получения:\n\n" +
            "1)Генерирование матрицы компьютером\n\n2)Введение матрицы пользователем в консоле\n\n" +
            "3)Считывание данных из файла");
        Console.WriteLine("При выборе 3 пункта, вы воспользуетесь уже готовыми матрицами, которые заранее подготовлены в файле");
        int flag = 0;
        int myChoice;
        do
        {
            Console.Write("Выберите пункт 1-3, введя соответствующую цифру: ");
            string myChoice0 = Console.ReadLine();
            if (!int.TryParse(myChoice0, out myChoice) | (myChoice < 1) | (myChoice > 3))
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        if (myChoice == 1)
        {
            // Матрица/ы генерируется компьютером.
            RandomGenerate(in NumberOfMatrix);
        }
        if (myChoice == 2)
        {
            // Матрица/ы вводятся пользователем через консоль.
            ConsoleGenerate(in NumberOfMatrix);
        }
        if (myChoice == 3)
        {
            // Матрица/ы импортируются из файла.
            FileGenerate(in NumberOfMatrix);
        }
    }

    /// <summary>
    /// Метод MatrixTrace находит след матрицы.
    /// </summary>
    static void MatrixTrace()
    {
        double trace = 0;
        int NumberOfMatrix = 1;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        Console.WriteLine("Помните, что след можно найти только у квадратной матрицы, где m=n");
        int flag = 0;
        do
        {
            Console.WriteLine("Введите значение строк(1,10)");
            n0 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов(1,10)");
            m0 = Console.ReadLine();
            if (!int.TryParse(n0, out n) | !int.TryParse(m0, out m) | n < 1 | n > 10 | m < 1 | m > 10 | n != m)
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);

        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
                Console.Write(matrixFirst[i, j] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine("Cлед данной матрицы равен:\n");
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
            {
                if (i == j)
                    trace += matrixFirst[i, j];
            }
        }
        Console.WriteLine(trace);
    }

    /// <summary>
    /// Метод MatrixTransposition выполняет транспонирование матрицы.
    /// </summary>
    static void MatrixTransposition()
    {
        int NumberOfMatrix = 1;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        int flag = 0;
        do
        {
            Console.WriteLine("Введите значение строк(1,10)");
            n0 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов(1,10)");
            m0 = Console.ReadLine();
            if (!int.TryParse(n0, out n) | !int.TryParse(m0, out m) | n < 1 | n > 10 | m < 1 | m > 10)
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
                Console.Write(matrixFirst[i, j] + "\t");
            Console.WriteLine();
        }
        double[,] resultMatrix = new double[m, n];
        Console.WriteLine("Матрица, тарнспонированная данной равна:\n");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                resultMatrix[i, j] = matrixFirst[j, i];
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

    }

    /// <summary>
    ///  Метод MatrixSum выполняет сложение двух матриц.
    /// </summary>
    static void MatrixSum()
    {
        int NumberOfMatrix = 2, flag = 0;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        Console.WriteLine("Не забудьте, что суммировать можно только матрицы одинаковых размеров");
        do
        {
            Console.WriteLine("Введите значение строк 1 матрицы (1-10)");
            string n01 = Console.ReadLine();
            Console.WriteLine("Введите значение стобцов 1 матрицы(1-10)");
            string m01 = Console.ReadLine();
            Console.WriteLine("Введите значение строк 2 матрицы(1-10)");
            string n02 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов 2 матрицы(1-10)");
            string m02 = Console.ReadLine();
            if (!int.TryParse(n01, out n1) | !int.TryParse(m01, out m1) | !int.TryParse(n02, out n2) | !int.TryParse(m02, out m2) | n1 != n2 | m1 != m2 | n1 > 10 | n1 < 1
                | m1 < 1 | m1 > 10 | n2 > 10 | n2 < 1 | m2 < 1 | m2 > 10)
            {
                Console.WriteLine("Ваши данные неккоректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);
        char b = '+';
        HelperForOutputs(in b);
        double[,] resultMatrix = new double[n1, m1];
        Console.WriteLine("\n=\n");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                resultMatrix[i, j] = matrixFirst[i, j] + matrixSecond[i, j];
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод MatrixSubtraction выполянет вычитание двух матриц.
    /// </summary>
    static void MatrixSubtraction()
    {
        int NumberOfMatrix = 2, flag = 0;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        Console.WriteLine("Не забудьте, что вычитать можно только матрицы одинаковых размеров");
        do
        {
            Console.WriteLine("Введите значение строк 1 матрицы (1-10)");
            string n01 = Console.ReadLine();
            Console.WriteLine("Введите значение стобцов 1 матрицы(1-10)");
            string m01 = Console.ReadLine();
            Console.WriteLine("Введите значение строк 2 матрицы(1-10)");
            string n02 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов 2 матрицы(1-10)");
            string m02 = Console.ReadLine();
            if (!int.TryParse(n01, out n1) | !int.TryParse(m01, out m1) | !int.TryParse(n02, out n2) | !int.TryParse(m02, out m2) | n1 != n2 | m1 != m2 | n1 > 10 | n1 < 1
                | m1 < 1 | m1 > 10 | n2 > 10 | n2 < 1 | m2 < 1 | m2 > 10)
            {
                Console.WriteLine("Ваши данные неккоректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);
        char b = '-';
        HelperForOutputs(in b);
        double[,] resultMatrix = new double[n1, m1];
        Console.WriteLine("\n=\n");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                resultMatrix[i, j] = matrixFirst[i, j] - matrixSecond[i, j];
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод MatrixMultiplication реализует произведение двух матриц.
    /// </summary>
    static void MatrixMultiplication()
    {
        int NumberOfMatrix = 2, flag = 1;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        Console.WriteLine("Помните, что для перемножения матриц кол-во столбцов первой должно совпадать с кол-вом строк во второй");
        do
        {
            Console.WriteLine("Введите значение строк 1 матрицы (1-10)");
            string n01 = Console.ReadLine();
            Console.WriteLine("Введите значение стобцов 1 матрицы(1-10)");
            string m01 = Console.ReadLine();
            Console.WriteLine("Введите значение строк 2 матрицы(1-10)");
            string n02 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов 2 матрицы(1-10)");
            string m02 = Console.ReadLine();
            if (!int.TryParse(n01, out n1) | !int.TryParse(m01, out m1) | !int.TryParse(n02, out n2) | !int.TryParse(m02, out m2) | m1 != n2 | n1 > 10 | n1 < 1
                | m1 < 1 | m1 > 10 | n2 > 10 | n2 < 1 | m2 < 1 | m2 > 10)
            {
                Console.WriteLine("Ваши данные неккоректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);
        char b = '*';
        HelperForOutputs(in b);
        Console.WriteLine("\n=\n");
        double[,] resultMatrix = new double[n1, m2];
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixSecond.GetLength(1); j++)
            {
                for (int r = 0; r < matrixSecond.GetLength(0); r++)
                {
                    resultMatrix[i, j] += matrixFirst[i, r] * matrixSecond[r, j];
                }
            }
        }
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод MatrixMultiNum реализует умножение матрицы на введённое пользователем число.
    /// </summary>
    static void MatrixMultiNum()
    {
        int NumberOfMatrix = 1, flag = 0;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        do
        {
            Console.WriteLine("Введите значение строк(1,10)");
            n0 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов(1,10)");
            m0 = Console.ReadLine();
            if (!int.TryParse(n0, out n) | !int.TryParse(m0, out m) | n < 1 | n > 10 | m < 1 | m > 10)
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        InputInstruction(in NumberOfMatrix);
        double yourNum1;
        int flag1 = 0;
        do
        {
            Console.Write("Введите число, на которое хотите умножить матрицу(-50,50): ");
            string yourNum = Console.ReadLine();
            if (!double.TryParse(yourNum, out yourNum1) | yourNum1 > 50 | yourNum1 < -50)
            {
                Console.WriteLine("Ваши данные некорректны");
                flag1 = 0;
            }
            else
                flag1 += 1;
        } while (flag1 == 0);
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
            {
                Console.Write(matrixFirst[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n*\n");
        Console.WriteLine(yourNum1);
        Console.WriteLine("=");
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
            {
                matrixFirst[i, j] *= yourNum1;
                Console.Write(matrixFirst[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод HelperForOutputs реализует вывод двух матриц для методов, где выполняются действия над двумя матрицами.
    /// </summary>
    static void HelperForOutputs(in char b)
    {
        for (int i = 0; i < matrixFirst.GetLength(0); i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
            {
                Console.Write(matrixFirst[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine(b);
        Console.WriteLine();
        for (int i = 0; i < matrixSecond.GetLength(0); i++)
        {
            for (int j = 0; j < matrixSecond.GetLength(1); j++)
            {
                Console.Write(matrixSecond[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод MatrixDeterminant реализует вызов методов для поиска определителя матрицы.
    /// </summary>
    static void MatrixDeterminant()
    {
        int NumberOfMatrix = 1, flag = 0;
        Console.WriteLine("Матрица задаётся размерами n на m, где n-строки, m-столбцы\nМаксимальный допустимый размер 10X10");
        Console.WriteLine("Помните, что для нахождения определителя вам нужна квадратная матрица, т.е m=n");
        do
        {
            Console.WriteLine("Введите значение строк(1,10)");
            n0 = Console.ReadLine();
            Console.WriteLine("Введите значение столбцов(1,10)");
            m0 = Console.ReadLine();
            if (!int.TryParse(n0, out n) | !int.TryParse(m0, out m) | n < 1 | n > 10 | m < 1 | m > 10 | m != n)
            {
                Console.WriteLine("Ваши данные некорректны");
                flag = 0;
            }
            else
                flag += 1;
        } while (flag == 0);
        double det = 0;
        InputInstruction(in NumberOfMatrix);
        for (int i = 0; i < matrixFirst.GetLength(0);i++)
        {
            for (int j = 0; j < matrixFirst.GetLength(1); j++)
            {
                Console.Write(matrixFirst[i,j]+"\t");
            }
            Console.WriteLine();
        }
        det = Determinant(matrixFirst);
        Console.WriteLine(det);
    }

    /// <summary>
    /// Метод Determinant считает определитель по минору.
    /// </summary>
    /// <returns>Возвращает в точку вызова значение определителя</returns>
    public static double Determinant(double[,] matrix1)
    {
        double det = 0;
        int Rank = matrix1.GetLength(0);
        if (Rank == 1) det = matrix1[0, 0];
        if (Rank == 2) det = matrix1[0, 0] * matrix1[1, 1] - matrix1[0, 1] * matrix1[1, 0];
        if (Rank > 2)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                det += Math.Pow(-1, 0 + j) * matrix1[0, j] * Determinant(GetMinor(matrix1, 0, j));
            }
        }
        return det;
    }

    /// <summary>
    /// Метод GetMinor считает минор матрицы (по значению строки).
    /// </summary>
    public static double[,] GetMinor(double[,] matrix1, int sTr, int sTl)
    {
        double[,] mass = new double[matrix1.GetLength(0) - 1, matrix1.GetLength(0) - 1];
        for (int i = 0; i < matrix1.GetLength(0); i++)
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                if ((i != sTr) || (j != sTl))
                {
                    if (i > sTr && j < sTl) mass[i - 1, j] = matrix1[i, j];
                    if (i < sTr && j > sTl) mass[i, j - 1] = matrix1[i, j];
                    if (i > sTr && j > sTl) mass[i - 1, j - 1] = matrix1[i, j];
                    if (i < sTr && j < sTl) mass[i, j] = matrix1[i, j];
                }
            }
        return mass;
    }

    /// <summary>
    /// Метод Main рассказывет пользователю инструкцию к калькулятору матриц.
    /// Выполняется вызов методов, с которых начинается основное решение.
    /// Также метод реализует повтор решения.
    /// </summary>
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Привет, перед Вами калькулятор матриц.\nВам предалгается достаточно много операций, которые Вы можете совершать с матрицами.\n");
            Console.WriteLine("Вам необходимо ввести цифру, в зависимости от того , какую оперцию над матрицей/ами вы хотите совершить:\n" +
                "1)нахождение следа матрицы;\n2)транспонирование матрицы;\n3)сумма двух матриц;\n4)разность двух матриц;\n" +
                "5)произведение двух матриц;\n6)умножение матрицы на число;\n7)нахождение определителя матрицы");
            CheckNumber(out number);
            WhatISNumber(number);
            Console.WriteLine("Если вы хотите запустить программу заново, то нажмите Enter\n" +
                "Если же хотите закончить, то нажмите любую другую клавишу");
        } while (Console.ReadKey().Key==ConsoleKey.Enter);
    }

    /// <summary>
    /// Метод RandomGenerate реализует заполнение матриц/ы рандомными числами.
    /// </summary>
    static void RandomGenerate(in int NumberOfMatrix)
    {
        if (NumberOfMatrix == 1)
        {
            matrixFirst = new double[n, m];
            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                    matrixFirst[i, j] = random.Next(-100, 100);
            }
        }
        if (NumberOfMatrix == 2)
        {
            matrixFirst = new double[n1, m1];
            matrixSecond = new double[n2, m2];
            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                    matrixFirst[i, j] = random.Next(-100, 100);
            }
            for (int i = 0; i < matrixSecond.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSecond.GetLength(1); j++)
                    matrixSecond[i, j] = random.Next(-100, 100);
            }
        }
    }

    /// <summary>
    /// Метод ConsoleGenerate позволяет пользователю ввести матрицу/ы с клавиатуры.
    /// </summary>
    static void ConsoleGenerate(in int NumberOfMatrix)
    {
        if (NumberOfMatrix == 1)
        {
            matrixFirst = new double[n, m];
            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                {
                    double a1;
                    int flag = 0;
                    do
                    {
                        Console.Write($"Введите {i} {j} элемент 1 матрицы (-100,100)  ");
                        string a = Console.ReadLine();
                        if (!double.TryParse(a, out a1) | a1 > 100 | a1 < -100)
                        {
                            Console.WriteLine("Ваши данные некорректны");
                            flag = 0;
                        }
                        else
                            flag += 1;
                    } while (flag == 0);
                    matrixFirst[i, j] = a1;
                }
            }
        }
        if (NumberOfMatrix == 2)
        {
            matrixFirst = new double[n1, m1];
            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                {
                    double a1;
                    int flag = 0;
                    do
                    {
                        Console.Write($"Введите {i} {j} элемент 1 матрицы (-100,100)  ");
                        string a = Console.ReadLine();
                        if (!double.TryParse(a, out a1) | a1 > 100 | a1 < -100)
                        {
                            Console.WriteLine("Ваши данные некорректны");
                            flag = 0;
                        }
                        else
                            flag += 1;
                    } while (flag == 0);
                    matrixFirst[i, j] = a1;
                }
            }
            matrixSecond = new double[n2, m2];
            for (int i = 0; i < matrixSecond.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSecond.GetLength(1); j++)
                {
                    double a1;
                    int flag = 0;
                    do
                    {
                        Console.Write($"Введите {i} {j} элемент 2 матрицы (-100,100)  ");
                        string a = Console.ReadLine();
                        if (!double.TryParse(a, out a1) | a1 > 100 | a1 < -100)
                        {
                            Console.WriteLine("Ваши данные некорректны");
                            flag = 0;
                        }
                        else
                            flag += 1;
                    } while (flag == 0);
                    matrixSecond[i, j] = a1;
                }
            }
        }
    }

    /// <summary>
    /// Метод FileGenerate вызывает методы для считывание матриц/ы из файла.
    /// В зависимости от выбранной операции калькулятора значения считываются из определённых файлов.
    /// </summary>
    static void FileGenerate(in int NumberOfMatrix)
    {
        if (number == 1 | number == 7 | number == 2 | number == 6)
            GenerateForOneSevTwoSix(in NumberOfMatrix);
        if (number == 3 | number == 4)
            GenerateForThreeFour();
        if (number == 5)
            GenerateForFive();
    }

    /// <summary>
    /// Метод GenerateForOneSevTwoSix считывает данные для матрицы из файла.
    /// Метод вызывает, если пользователь выбрал 1,2,6 или 7 операции.
    /// </summary>
    static void GenerateForOneSevTwoSix(in int NumberOfMatrix)
    {
        int N = 0, M = 0;
        if (NumberOfMatrix == 1)
        {
            if (number == 1 | number == 7)
                str = File.ReadAllLines("Trace and Det.txt");
            if (number == 2 | number == 6)
                str = File.ReadAllLines("Transposition and MultiNum.txt");
            if (str.Length == 0)
            {
                Console.WriteLine("Ваш файл пуст, измените его, а затем запустите программу заново");
                Environment.Exit(0);
            }
            string num = str[0];
            if (!int.TryParse(num[0].ToString(), out N) | !int.TryParse(num[2].ToString(), out M) | N > 10 | N < 1 | M < 1 | M > 10)
            {
                Console.WriteLine("Данные для размера матрицы некорректны");
                Environment.Exit(0);
            }
            if (N != (str.Length - 1))
            {
                Console.WriteLine("Кол-во столбцов не совпадает");
                Environment.Exit(0);
            }
            matrixFirst = new double[N, M];
            int k;
            for (int i = 1; i < str.Length; i++)
            {
                k = -1;
                string[] num1 = str[i].Split(' ');
                double x;
                if (num1.Length != M)
                {
                    Console.WriteLine("Кол-во строк не совпадает");
                    Environment.Exit(0);
                }
                for (int j = 0; j < num1.Length; j++)
                {
                    if (num1[j].ToString() != " ")
                    {
                        k += 1;
                        if (!double.TryParse(num1[j].ToString(), out x) | x > 100 | x < -100)
                        {
                            Console.WriteLine("Данные матрицы некорректны");
                            Environment.Exit(0);
                        }
                        else
                        {
                            matrixFirst[i - 1, k] = x;
                        }
                    }
                }
            }
        }
        n = N;
        m = M;
    }

    /// <summary>
    /// Метод GenerateForOneSevTwoSix считывает данные для матрицы из файла, если пользователь выбрал 3 или 4 операции.
    /// </summary>
    static void GenerateForThreeFour()
    {
        int N = 1, M = 1;

        str1 = File.ReadAllLines("Sum Sub 1.txt");
        str2 = File.ReadAllLines("Sum Sub 2.txt");
        if (str1.Length == 0 | str2.Length == 0)
        {
            Console.WriteLine("Ваш файл пуст, измените его, а затем запустите программу заново");
            Environment.Exit(0);
        }
        string num = str1[0];
        if (!int.TryParse(num[0].ToString(), out N) | !int.TryParse(num[2].ToString(), out M) | N > 10 | N < 1 | M < 1 | M > 10)
        {
            Console.WriteLine("Данные для размера матрицы некорректны");
            Environment.Exit(0);
        }
        if (str1.Length - 1 != N | str2.Length - 1 != N)
        {
            Console.WriteLine("Кол-во столбцов не совпадает");
            Environment.Exit(0);
        }
        matrixFirst = new double[N, M];
        int k1;
        for (int i = 1; i < str1.Length; i++)
        {
            k1 = -1;
            string[] num11 = str1[i].Split(' ');
            double x;
            if (num11.Length != M)
            {
                Console.WriteLine("Кол-во строк не совпадает");
                Environment.Exit(0);
            }
            for (int j = 0; j < num11.Length; j++)
            {
                if (num11[j].ToString() != " ")
                {
                    k1 += 1;
                    if (!double.TryParse(num11[j].ToString(), out x) | x > 100 | x < -100)
                    {
                        Console.WriteLine("Данные матрицы некорректны");
                        Environment.Exit(0);
                    }
                    else
                    {
                        matrixFirst[i - 1, k1] = x;
                    }
                }
            }
        }
        matrixSecond = new double[N, M];
        int k2;
        for (int i = 1; i < str2.Length; i++)
        {
            k2 = -1;
            string[] num22 = str2[i].Split(' ');
            double x;
            if (num22.Length != M)
            {
                Console.WriteLine("Кол-во строк не совпадает");
                Environment.Exit(0);
            }
            for (int j = 0; j < num22.Length; j++)
            {
                if (num22[j].ToString() != " ")
                {
                    k2 += 1;
                    if (!double.TryParse(num22[j].ToString(), out x) | x > 100 | x < -100)
                    {
                        Console.WriteLine("Данные матрицы некорректны");
                        Environment.Exit(0);
                    }
                    else
                    {
                        matrixSecond[i - 1, k2] = x;
                    }
                }
            }

        }
        n1 = N;
        m1 = M;
    }

    /// <summary>
    /// Метод реализует считывание из файла для 5 операции.
    /// </summary>
    static void GenerateForFive()
    {
        int N1 = 0, M1 = 0, N2 = 0, M2 = 0;
        str1 = File.ReadAllLines("Multiplication 1.txt");
        str2 = File.ReadAllLines("Multiplication 2.txt");
        if (str1.Length == 0 | str2.Length == 0)
        {
            Console.WriteLine("Ваш файл пуст, измените его, а затем запустите программу заново");
            Environment.Exit(0);
        }
        string num = str1[0];
        if (!int.TryParse(num[0].ToString(), out N1) | !int.TryParse(num[2].ToString(), out M1) | N1 > 10 | N1 < 1 | M1 < 1 | M1 > 10)
        {
            Console.WriteLine("Данные для размера матрицы некорректны");
            Environment.Exit(0);
        }
        string num1 = str2[0];
        if (!int.TryParse(num1[0].ToString(), out N2) | !int.TryParse(num1[2].ToString(), out M2) | N2 > 10 | N2 < 1 | M2 < 1 | M2 > 10)
        {
            Console.WriteLine("Данные для размера матрицы некорректны");
            Environment.Exit(0);
        }
        if (str1.Length - 1 != N1 | str2.Length - 1 != N2)
        {
            Console.WriteLine("Кол-во столбцов не совпадает");
            Environment.Exit(0);
        }
        matrixFirst = new double[N1, M1];
        int k1;
        for (int i = 1; i < str1.Length; i++)
        {
            k1 = -1;
            string[] num11 = str1[i].Split(' ');
            double x;
            if (num11.Length != M1)
            {
                Console.WriteLine("Кол-во строк не совпадает");
                Environment.Exit(0);
            }
            for (int j = 0; j < num11.Length; j++)
            {
                if (num11[j].ToString() != " ")
                {
                    k1 += 1;
                    if (!double.TryParse(num11[j].ToString(), out x) | x > 100 | x < -100)
                    {
                        Console.WriteLine("Данные матрицы некорректны");
                        Environment.Exit(0);
                    }
                    else
                    {
                        matrixFirst[i - 1, k1] = x;
                    }
                }
            }
        }
        matrixSecond = new double[N2, M2];
        int k2;
        for (int i = 1; i < str2.Length; i++)
        {
            k2 = -1;
            string[] num22 = str2[i].Split(' ');
            double x;
            if (num22.Length != M2)
            {
                Console.WriteLine("Кол-во строк не совпадает");
                Environment.Exit(0);
            }
            for (int j = 0; j < num22.Length; j++)
            {
                if (num22[j].ToString() != " ")
                {
                    k2 += 1;
                    if (!double.TryParse(num22[j].ToString(), out x) | x > 100 | x < -100)
                    {
                        Console.WriteLine("Данные матрицы некорректны");
                        Environment.Exit(0);
                    }
                    else
                    {
                        matrixSecond[i - 1, k2] = x;
                    }
                }
            }
        }
        n1 = N1;
        n2 = N2;
        m1 = M1;
        m2 = M2;
    }
}