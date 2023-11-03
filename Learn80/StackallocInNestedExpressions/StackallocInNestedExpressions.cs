using System;

namespace Learn80.StackallocInNestedExpressions
{
    public static class StackallocInNestedExpressions
    {
        public static void Test()
        {
            StackAllocExample();
        }

        private static void StackAllocExample()
        {
            //Before C# 7.2
            unsafe
            {
                //Allocate Some Memory on the stack using stackalloc
                //Int = 4 Bytes, so it will allocate 40 (10*4) Bytes of Memory in Stack
                int* ptr = stackalloc int[10];
                for (int i = 0; i < 10; i++)
                {
                    ptr[i] = i + 1;
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"{ptr[i]} ");
                }
            } 
            //C# 7.2
            //Allocate Some Memory on the stack using stackalloc
            //Int = 4 Bytes, so it will allocate 40 (10*4) Bytes of Memory in Stack
            //Using Span<int>, so unsafe block is not required
            Span<int> ptr2 = stackalloc int[10];
            for (int i = 0; i < 10; i++)
            {
                ptr2[i] = i + 1;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{ptr2[i]} ");
            }
            
            //C# 7.3
            //Initialzing Array without stackalloc
            var arr1 = new int[5] { 1, 4, 9, 16, 25 };
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{arr1[i]} ");
            }
            Console.WriteLine();
            var arr2 = new int[] { 1, 2, 4, 8 };
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{arr2[i]} ");
            }
            Console.WriteLine();
            //Initialzing Array with stackalloc
            unsafe
            {
                int* pArr1 = stackalloc int[5] { 1, 4, 9, 16, 25 }; //7.3
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{pArr1[i]} ");
                }
                Console.WriteLine();
                int* pArr2 = stackalloc int[] { 1, 2, 4, 8 }; //7.3
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"{pArr2[i]} ");
                }
            }
            Console.WriteLine();
            //Initialzing Array with stackalloc and Span<T>
            //Here, unsafe block is not required
            Span<int> ptr1 = stackalloc int[5] { 1, 4, 9, 16, 25 }; //7.3
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{ptr1[i]} ");
            }
            Console.WriteLine();
            Span<int> ptr3 = stackalloc int[] { 1, 2, 4, 8 }; //7.3
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{ptr3[i]} ");
            }
            
            //c# 8.0
            //Storing the result of stackalloc in Span<int>
            Span<int> numbers = stackalloc int[] { 10, 20, 30, 40, 50, 60, 70, 80, 80, 100 }; //7.3
            //Now we can use stackalloc expression i.e. numbers in other expressions
            //IndexOfAny: Searches for the first index of any of the specified values.
            var index = numbers.IndexOfAny(stackalloc[] {11, 40, 60, 100 }); // 8.0
            Console.WriteLine(index); // output: 3  
            
            //Example2:
            //Storing the result of stackalloc in Span<int> so that we can resue it in another expression
            Span<int> set = stackalloc int[6] { 1, 2, 3, 4, 5, 6 }; //7.3
            //Reusing stackalloc expression  
            //Forms a slice out of the current span starting at a specified index for a specified length.
            Span<int> subSet = set.Slice(3, 2);
            foreach (var n in subSet)
            {
                Console.WriteLine(n); // Output: 4 5
            }
        }
    }
}