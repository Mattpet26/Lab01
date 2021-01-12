using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            StartSequence();
            }
            catch(Exception e)
            {
                Console.WriteLine("Oops, looks like something went wrong");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program completed");
            }
        }
        public static void StartSequence()
        {
            try
            {
                Console.WriteLine("Lets play a game. Enter a number greater than 0");
                int input = Convert.ToInt32(Console.ReadLine());
                int[] numberArray = new int[input];
                numberArray = Populate(numberArray);
                Console.WriteLine("The numbers in your array are: ");
                for(int i = 0; i < numberArray.Length; i++)
                {
                    Console.Write($"{numberArray[i]}");
                }
                Console.WriteLine(" ");
                int sumNumbers = GetSum(numberArray);
                int productNums = GetProduct(numberArray, sumNumbers);
                decimal userQuotient = GetQuotient(productNums);

                Console.WriteLine($"The sum of your entered array is: {sumNumbers}");
                Console.WriteLine($"The product of {sumNumbers} and {productNums / sumNumbers} is: {productNums}");
                Console.WriteLine($"The quotient of {productNums} and {productNums / userQuotient} is: {userQuotient}.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, that was not a number");
                Console.WriteLine(e.Message);
                StartSequence();
            }
        }
        public static int[] Populate(int[] numberArray)
        {
            for(int i = 0; i < numberArray.Length; i++)
            {
                Console.WriteLine($"Enter a number to populate the array: {i + 1} of {numberArray.Length}");
                string userAnswer = Console.ReadLine();
                numberArray[i] = Convert.ToInt32(userAnswer);
            }
            return numberArray;
        }
        public static int GetSum(int[] numberArray)
        {
            int sum = 0;
            for(int i = 0; i < numberArray.Length; i++)
            {
                sum += numberArray[i];
            }
            return sum;
        }
        public static int GetProduct(int[] numberArray, int sumNumbers)
        {
            try
            {
            Console.WriteLine($"Please enter a random number between 1 and {numberArray.Length}");
            string input = Console.ReadLine();
            int product = sumNumbers * numberArray[Convert.ToInt32(input) - 1];

            return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Looks like that number was not between 1 and {numberArray.Length}");
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static decimal GetQuotient(int productNums)
        {
            try
            {
                Console.WriteLine($"Enter a number that we can divide {productNums} by.");
                string input = Console.ReadLine();
                decimal number = decimal.Divide(Convert.ToDecimal(productNums), Convert.ToDecimal(input));
                return number;
            }
            catch(DivideByZeroException dz)
            {
                Console.WriteLine(dz.Message);
                return 0;
            }
        }
    }
}
