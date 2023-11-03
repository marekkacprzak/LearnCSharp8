using System;

namespace Learn80.UnmanagedConstructedTypes
{
    public static class UnmanagedConstructedTypes
    {
        public static void Test()
        {
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();
            
            // Block of memory
            Span<Foo<int>> bars = stackalloc[]
            {
                new Foo<int> { var1 = 10, var2 = 20, var3 = 30 },
                new Foo<int> { var1 = 11, var2 = 21, var3 = 31 },
                new Foo<int> { var1 = 21, var2 = 22, var3 = 32 },
            };
            foreach (var bar in bars)
            {
                Console.WriteLine($"Var1: {bar.var1}, Var2: {bar.var2}, Var3: {bar.var3}");
            }
        }
        //Beginning with C# 8.0, a constructed struct type that contains fields of unmanaged types only is also unmanaged
        public struct Coords<T> where T : unmanaged
        {
            public T X;
            public T Y;
        }
        public struct Foo<T> where T : unmanaged
        {
            public T var1;
            public T var2;
            public T var3;
        }

        private unsafe static void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
    }
}