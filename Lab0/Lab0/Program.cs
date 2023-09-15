namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------------------------------
            // Tasks 1 & 2
            int low, high;

            while (true)
            {
                Console.Write("Enter a low integer: ");
                low = int.Parse(Console.ReadLine());

                if (low <= 0)
                {
                    Console.WriteLine("low should be a positive integer!");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter a high integer: ");
                high = int.Parse(Console.ReadLine());

                if (high <= low)
                {
                    Console.WriteLine("high should be greater than low!");
                    continue;
                }

                break;
            }

            int difference = high - low;
            Console.WriteLine($"The difference high - low is = {difference}");
            // --------------------------------------

            // --------------------------------------
            // Task 3

            int[] numbers = new int[difference + 1];
            for (int i = low; i <= high; i++)
            {
                numbers[i - low] = i;
            }

            Console.WriteLine("Creating a file called numbers.txt");
            StreamWriter sw = File.CreateText("numbers.txt");

            Console.WriteLine($"Writing all integers from {low} to {high} into numbers.txt in reverse order");

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                sw.WriteLine(numbers[i]);
            }

            sw.Close();
            Console.WriteLine("Done, closing numbers.txt");
            // --------------------------------------

            // --------------------------------------
            // Additional tasks

            Console.WriteLine("Reading numbers from file numbers.txt");
            Console.WriteLine("Storing numbers in a list as doubles");

            List<double> listNumbers = new List<double>();
            StreamReader sr = new StreamReader("numbers.txt");

            while (true)
            {
                String line = sr.ReadLine();

                if(line == null)
                {
                    sr.Close();
                    break;
                }

                listNumbers.Add(double.Parse(line));
            }

            double result = 0.0;
            foreach (double n in listNumbers)
            {
                result += n;
            }

            Console.WriteLine($"Sum of all numbers from {low} to {high} is = {result}");

            Console.WriteLine($"Printing all prime numbers between {low} and {high}");
            foreach (int i in numbers)
            {
                if (CheckPrime(i))
                {
                    Console.WriteLine($"{i} is a prime number");
                }
            }
            // --------------------------------------
        }

        static bool CheckPrime(int n)
        {
            int divisors = 0;

            for (int x = 1; x <= n; x++)
            {
                if ((n % x) == 0)
                {
                    divisors++;
                }
            }

            if(divisors == 2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}