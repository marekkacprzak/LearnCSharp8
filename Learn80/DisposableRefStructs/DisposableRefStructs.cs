using System;

namespace Learn80.DisposableRefStructs
{
    public static class DisposableRefStructs
    {
        public static void Test()
        {
            using var book = new Rectangle(10, 20);
            Console.WriteLine($"Area of Rectangle : {book.GetArea()}");
            Console.WriteLine("Main Method End");
        }

        //Ref structs can now be disposable without implementing the IDisposable interface, simply by having a Dispose method in them.
        ref struct Rectangle
        {
            private double Height { get; set; }
            private double Width { get; set; }
            public Rectangle(double height, double width)
            {
                Height = height;
                Width = width;
            }
            public double GetArea()
            {
                return Height * Width;
            }
            public void Dispose()
            {
                Console.WriteLine("Rectangle Object Disposed Of");
            }
        }
    }
}