using System;
namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op) // присвоение числам типа данных с плавающей точкой (т.е. все действительные числа)
        {
            double result = double.NaN; // Если используемое по умолчанию значение - " не число", которое мы используем, то при использовании операции деления, может выдать ошибку 

            switch (op) // для выполнения математических операций (сложение, вычитание, умножение, деление) используем оператор свитч 
            {
                case "a": //условный оператор, если значение вводимых данных равно "а"
                    result = num1 + num2;
                    break; // завершилось выполнение блока команд
                case "s": //условный оператор, если значение вводимых данных равно "s"
                    result = num1 - num2;
                    break; // завершилось выполнение блока команд
                case "m": //условный оператор, если значение вводимых данных равно "m"
                    result = num1 * num2;
                    break; // завершилось выполнение блока команд
                case "d": //условный оператор, если значение вводимых данных равно "d"

                    if (num2 != 0) // условие, запрещающее ввод нулевого делителя
                    {
                        result = num1 / num2;
                    }
                    break;
                // Возвращаем текст для неверного ввода 
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r"); // Названия нашего калькулятора
            Console.WriteLine("------------------------\n"); // Название указанной строки
            while (!endApp)
            {

                string numInput1 = ""; // Объявление "пустой" переменной 
                string numInput2 = ""; // Объявление "пустой" переменной
                double result = 0;

                Console.Write("Type a number, and then press Enter: "); // Ввод первого числа
                numInput1 = Console.ReadLine(); // Считывание первого введенного числа
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: "); // Ввод второго числа
                numInput2 = Console.ReadLine(); // Считывание второго введенного числа
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) // цикл while
                {
                    Console.Write("This is not valid input. Please enter an integer value: "); // Вывод строки "...". Ввод корректного значения
                    numInput2 = Console.ReadLine(); // Считывание
                }
                // Выбор оператора (математическая операция)
                Console.WriteLine("Choose an operator from the following list:"); // Вывод строки "..." на экран.
                Console.WriteLine("\ta - Add"); // Математическая операция (сложение) 
                Console.WriteLine("\ts - Subtract"); // Математическая операция (разность) 
                Console.WriteLine("\tm - Multiply"); // Математическая операция (умножение) 
                Console.WriteLine("\td - Divide"); // Математическая операция (деление) 
                Console.Write("Your option? "); // Вывод на экран строки "...". Ввод нужной математической операции
                string op = Console.ReadLine(); // Считывание введенного значения
                try // Блок обработки исключительных ситуаций, возникших при выполнении нашего кода
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result); // форматированный вывод
                }
                catch (Exception e) //Блок обработки исключительных ситуаций, возникших при выполнении нашего кода
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------\n");
                // Ожидание ввода n и нажатие Enter перед закрытием
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true; // Конструкция if выполняет блок кода, если заданное условие — истинно, т. е. true
                Console.WriteLine("\n");
            }
            return;
        }
    }
}