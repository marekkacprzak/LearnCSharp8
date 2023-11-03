using System;
using System.IO;
using System.Threading.Tasks;

namespace Learn80.AsynchronousDisposable
{
    public static class AsynchronousDisposable
    {
        public static async void Test()
        { 
            await using (var disposableObject = new Sample())
            {
                Console.WriteLine("Welcome to C#.NET");
            } // DisposeAsync method called implicitly
            Console.WriteLine("Main Method End");
            
            await using (var disposableObject = new SampleInherited())
            {
                Console.WriteLine("Welcome to C#.NET SampleInherited");
            }// DisposeAsync method called implicitly
            Console.WriteLine("Main Method End SampleInherited");
        }
        public class Sample : IAsyncDisposable
        {
            static readonly string filePath = @"C:\tmp\DeleteMe.txt";
            private TextWriter? textWriter = File.CreateText(filePath);

            public async ValueTask DisposeAsync()
            {
                if (textWriter != null)
                {
                    textWriter.Dispose();
                    textWriter = null;
                }
                Console.WriteLine("DisposeAsync Clean-up the Memory!");
                await Task.Delay(10);
            }
        }
        public class Sample2 : IDisposable,IAsyncDisposable
        {
            static readonly string filePath = @"C:\tmp\MyTextFile2.txt";
            private TextWriter? textWriter = File.CreateText(filePath); 
            private Stream? disposableResource = new MemoryStream();
            private Stream? asyncDisposableResource = new MemoryStream();
            public void Dispose()
            {
                GC.SuppressFinalize(this);
                Console.WriteLine("Dispose Clean-up the Memory!");
            }
            public async ValueTask DisposeAsync()
            {
                await DisposeAsyncCore().ConfigureAwait(false);
                Dispose();
                GC.SuppressFinalize(this);
                Console.WriteLine("DisposeAsync Clean-up the Memory!");
            }
            protected virtual async ValueTask DisposeAsyncCore()
            {
                if (asyncDisposableResource != null)
                {
                    await asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
                }
                if (disposableResource is IAsyncDisposable disposable)
                {
                    await disposable.DisposeAsync().ConfigureAwait(false);
                }
                else
                {
                    disposableResource?.Dispose();
                }
                asyncDisposableResource = null;
                disposableResource = null;

                if (textWriter != null)
                {
                    await textWriter.DisposeAsync().ConfigureAwait(false);
                }
                textWriter = null;
                Console.WriteLine("Virtual DisposeAsyncCore Clean-up the Memory");
            }
        }
        public class SampleInherited : Sample2
        {
            protected override async ValueTask DisposeAsyncCore()
            {
                await base.DisposeAsyncCore();
                Console.WriteLine("Subclass DisposeAsyncCore Clean-up the Memory");
            }
        }
    }
}