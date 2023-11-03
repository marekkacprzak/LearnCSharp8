using System;

namespace Learn80.UsingDeclarations
{
    public static class UsingDeclarations
    {
        public static void Test()
        {
            using var resource = new Resource();
            resource.ResourceUsing();
            Console.WriteLine("Doing Some Other Task...");
        }//Here, the resource.Dispose() Method is called automatically
        class Resource : IDisposable
        {
            public Resource()
            {
                Console.WriteLine("Resource Created...");
            }
            public void ResourceUsing()
            {
                Console.WriteLine("Resource Using...");
            }
            public void Dispose()
            {
                Console.WriteLine("Resource Disposed...");
            }
        }
    }
}