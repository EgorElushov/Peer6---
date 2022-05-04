using System;
using System.IO;
using System.Text;
using EKRLib;

namespace peer
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    internal class Program
    {
        static string lettersAndNumbersString;
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            lettersAndNumbersString = GetLettersString();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nДля запуска программы введите 's'.");
            Console.WriteLine("Для выхода нажмите Enter.\n");
            string userInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();
                Console.Clear();
                if (userInput == "s")
                {
                    Transport[] transports;
                    transports = GenerateTransportMassive();
                    WriteToTxt(transports);
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine("\nДля продолжения программы введите 's'.");
                    Console.WriteLine("Для выхода нажмите Enter.\n");
                }

            } while (userInput == "s");
            Console.WriteLine("\nДо встречи!\n");
        }

        /// <summary>
        /// Получение массива заглавных букв и цифр.
        /// </summary>
        /// <returns>Массив заглавных букв и цифр.</returns>
        private static string GetLettersString()
        {
            StringBuilder stringOfLettersAndNumbers = new();
            for (var i = 'A'; i <= 'Z'; i++)
                stringOfLettersAndNumbers.Append(i);
            for (var i = 0; i <= 9; i++)
                stringOfLettersAndNumbers.Append(i);
            return stringOfLettersAndNumbers.ToString();
        }

        /// <summary>
        /// Генерация случайной строки, удовлетворяющей условиям модели
        /// транспортного средства.
        /// </summary>
        /// <returns>Случайно сгенерированная модель транспортного средства.</returns>
        private static string GenerateRandomString()
        {
            Random random = new();
            StringBuilder stringOfRandomModel = new();
            for (var j = 0; j < 5; j++)
            {
                int randomIndex = random.Next(0, lettersAndNumbersString.Length);
                stringOfRandomModel.Append(lettersAndNumbersString[randomIndex]);
            }
            return stringOfRandomModel.ToString();
        }

        /// <summary>
        /// Генерация массива случайных транспортных средств.
        /// </summary>
        /// <returns>Массив случайносгенерированных транспортных средств.</returns>
        private static Transport[] GenerateTransportMassive()
        {
            Random random = new();
            int randomSize = random.Next(6, 10);
            Transport[] transports = new Transport[randomSize];
            for (var i = 0; i < randomSize; i++)
            {
                transports[i] = GenerateObjects();
            }
            return transports;
        }

        /// <summary>
        /// Генерация одного объекта транспорта.
        /// </summary>
        /// <returns>Транспортное средство.</returns>
        private static Transport GenerateObjects()
        {
            Random random = new();
            int randomChoice = random.Next(0, 2);
            while (true)
            {
                try
                {
                    if (randomChoice == 0)
                    {
                        Transport car = new Car(GenerateRandomString(), (uint)random.Next(10, 100));
                        Console.WriteLine(car.StartEngine());
                        return car;
                    }
                    if (randomChoice == 1)
                    {
                        Transport motorBoat = new MotorBoat(GenerateRandomString(), (uint)random.Next(10, 100));
                        Console.WriteLine(motorBoat.StartEngine());
                        return motorBoat;
                    }
                }
                catch (TransportException exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
            }
        }

        /// <summary>
        /// запись информации о транспорте в файл.
        /// </summary>
        /// <param name="transports">Массив транспортных средств.</param>
        static void WriteToTxt(Transport[] transports)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new (path);
            string newPath = directoryInfo.Parent.Parent.Parent.Parent.FullName;

            foreach (var transport in transports)
            {
                if (transport is Car)
                {
                    File.AppendAllText(newPath + "/Cars.txt", $"{transport} \n", Encoding.Unicode);
                }
                else if (transport is MotorBoat)
                {
                    File.AppendAllText(newPath + "/MotorBoats.txt", $"{transport} \n", Encoding.Unicode);
                }
            }
        }
    }
}
