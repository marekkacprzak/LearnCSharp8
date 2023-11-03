using System;

namespace Learn80.StaticLocalFunctions
{
    public static class StaticLocalFunctions
    {
        public static void Test()
        {
            Calculate();
        }
        public static void Calculate()
        {
            int X = 20, Y = 30;
            CalculateSum(X, Y);
            static void CalculateSum(int Num1, int Num2)
            {
                int sum = Num1 + Num2;
                Console.WriteLine($"Num1 = {Num1}, Num2 = {Num2}, Result = {sum}");
            }
            CalculateSum(30, 10);
            CalculateSum(80, 60);
        }
    }
}