using System;

namespace Learn80.Null_coalescingAssignment
{
    public static class Null_coalescingAssignment
    {
        public static void Test()
        {
            // We can use this ??= operator in C# to assign the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null. That means the null-coalescing assignment operator ??= assigns a variable only if it is null. 
            int? Age = null;
            Age ??= 20;
            Console.WriteLine(Age);
        }
    }
}