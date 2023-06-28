namespace Library
{
    public class ZadanieOne
    {
        public void One()
        {
            Console.Write("Введите число N: ");
            int endValue;
            bool isValidInput = int.TryParse(Console.ReadLine(), out endValue);

            while (!isValidInput || endValue <= 0)
            {
                Console.WriteLine("Некорректный ввод. Введите положительное целое число.");
                isValidInput = int.TryParse(Console.ReadLine(), out endValue);
            }
            PrintSequence(1, endValue);
        }
        private void PrintSequence(int startValue, int endValue)
        {
            for (int i = startValue; i <= endValue; i++)
            {
                Console.Write(i);

                if (i < endValue)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(".");
        }
    }
    public class ZadanieTwo
    {
        public static void Two()
        {
            Console.Write("Введите нечетное число N: ");

            int size;
            bool isValidInput = int.TryParse(Console.ReadLine(), out size);

            while (!isValidInput || size < 3 || size % 2 == 0)
            {
                Console.WriteLine("Некорректный ввод. Введите нечетное число, большее 3.");
                isValidInput = int.TryParse(Console.ReadLine(), out size);
            }
            DrawSquare(size);
        }

        static void DrawSquare(int size)
        {
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
