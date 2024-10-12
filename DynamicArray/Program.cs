namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] numbers = Array.Empty<int>();
            string userInput = string.Empty;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                foreach (var number in numbers)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
                Console.WriteLine($"Введите число или {CommandSum}, для суммирования введённых ранее чисел.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    default:
                        if (int.TryParse(userInput, out int newNumber))
                        {
                            int[] numbersBuffer = new int[numbers.Length];

                            for (int i = 0; i < numbersBuffer.Length; i++)
                            {
                                numbersBuffer[i] = numbers[i];
                            }

                            numbers = new int[numbers.Length + 1];
                            numbers[numbers.Length - 1] = newNumber;

                            for (int i = 0; i < numbersBuffer.Length; i++)
                            {
                                numbers[i] = numbersBuffer[i];
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\"{userInput}\" не является числом или командой");
                            Console.ReadKey();
                            break;
                        }
                        break;

                    case CommandSum:
                        int sumOfNumbers = 0;

                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sumOfNumbers += numbers[i];
                        }

                        Console.WriteLine($"Сумма введенных ранее чисел: {sumOfNumbers}");
                        Console.ReadKey();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}
