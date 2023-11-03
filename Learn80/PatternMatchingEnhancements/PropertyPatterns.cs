using System;

namespace Learn80.PatternMatchingEnhancements
{
    public static class PropertyPatterns
    {
        public class Rectangle
        {
            public double Length { get; set; }
            public double Height { get; set; }
        }
        public class Address
        {
            public string? State { get; set; }
        }
        public static void IsSpecificRectangle(Rectangle rectangle)
        {
            if (rectangle is Rectangle { Length: 5, Height: 10 } specificRectangle)
            {
                Console.WriteLine($"Rectangle Length: {specificRectangle.Length} and Height: {specificRectangle.Height}");
            }
        }
        public static double ComputeSalesTax(Address location, double salePrice)
        {
            var salesTax = location switch
            {
                { State: "DELHI" } => salePrice * 0.06,
                { State: "MUMBAI" } => salePrice * 0.075,
                { State: "PUNE" } => salePrice * 0.05,
                _ => 0
            };
            return salesTax;
        }
        public static void Test()
        {
            var rectangle = new Rectangle {Length = 5, Height = 10};
            IsSpecificRectangle(rectangle);
            
            var salePrice = 100;
            var address = new Address { State = "DELHI" };
            var salesTax = ComputeSalesTax(address, salePrice);
            Console.WriteLine($"State: {address.State}, salePrice: {salePrice}, and salesTax: {salesTax}");
        }
        
    }
}