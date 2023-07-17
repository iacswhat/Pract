namespace Library
{

    public class Parser
    {
        public static int ParseInt(int task)
        {
            int endValue;
            bool isValidInput = int.TryParse(Console.ReadLine(), out endValue);
            
            switch (task)
            {
                case 1:
                    while (!isValidInput || endValue <= 1)
                    {
                        Console.WriteLine("Некорректный ввод.");
                        isValidInput = int.TryParse(Console.ReadLine(), out endValue);
                    }
                    break;

                case 2:
                    while (!isValidInput || endValue < 3 || endValue % 2 == 0)
                    {
                        Console.WriteLine("Некорректный ввод.");
                        isValidInput = int.TryParse(Console.ReadLine(), out endValue);
                    }
                    break;
            }
            return endValue;
        }
    }

    public class TaskOne
    {
        public static void One()
        {
            Console.Write("Введите число N: ");
            int endValue = Parser.ParseInt(1);
            Console.Write(string.Join(", ", Enumerable.Range(1, endValue)));
            Console.WriteLine(".");
        }
    }

    public class TaskTwo
    {
        public static void Two()
        {
            Console.Write("Введите нечетное число N больше 3: ");
            int size = Parser.ParseInt(2);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == size / 2 && j == size / 2)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
