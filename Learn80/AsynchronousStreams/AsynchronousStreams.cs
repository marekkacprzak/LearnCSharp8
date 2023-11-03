using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Learn80.AsynchronousStreams
{
    public static class AsynchronousStreams
    {
        public static async Task Test()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(millisecondsDelay:1000);
            var numbersAsync = GetNumbersAsync(1, 10, cancellationTokenSource.Token);
            await foreach (var number in numbersAsync)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
        }

        private static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(10);
                yield return i;
            }
        }

        private static async IAsyncEnumerable<int> GetNumbersAsync(int start, int end, [EnumeratorCancellation] CancellationToken token = default)
        {
            var random = new Random();
            for (int i = start; i < end; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation has been requested...");
                    // Perform cleanup if necessary.
                    //...
                    // Terminate the operation.
                    break;
                }
                await Task.Delay(random.Next(500, 1500));
                yield return i;
            }
        }
    }
}