using System;

namespace DemoLaskin
{
    interface ICalculator
    {
        int Add(int number1, int number2);
        int Multiply(int number1, int number2);
    }
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
