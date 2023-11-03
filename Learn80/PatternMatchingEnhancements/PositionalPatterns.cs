using System;

namespace Learn80.PatternMatchingEnhancements
{
    public static class PositionalPatterns
    {
        public static bool IsFreeShippingEligible(Customer customer)
        {
            // If customer is from the USA then Free shipping applies.  
            return customer is Customer(_, _, _, (_, _, "USA"));
        }
        public static void Test()
        {
            var rectangle = new Rectangle { Length = 20, Height = 40 };
            var (length, height) = rectangle;
            Console.WriteLine($"The rectangle Length: {length} and Height: {height}");
            if (rectangle is (20, _) rect) //Discards (_) 
            {
                Console.WriteLine("The rectangle has a length of 20");
            }
            
            var customer = new Customer()
            {
                FirstName = "Sam",
                LastName = "Taylor",
                Email = "info@dotnettutorials.net",
                CustomerAddress = new Address() { PostalCode = 755019, Street = "Newyork", Country = "USA"}
            };
            Console.WriteLine($"Is Free Shipping Eligible : {IsFreeShippingEligible(customer)}");
            customer.CustomerAddress.Country = "Poland";
            Console.WriteLine($"Is Free Shipping Eligible : {IsFreeShippingEligible(customer)}");
            
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            // Using discard in lambda expression
            var squaredNumbers = Array.ConvertAll(numbers, _ => _ * _);
            // Displaying the squared numbers
            Console.WriteLine("Squared numbers:");
            foreach (var num in squaredNumbers)
            {
                Console.WriteLine(num);
            }
        }
        public class Rectangle
        {
            public double Length { get; set; }
            public double Height { get; set; }
            public void Deconstruct(out double length, out double height)
            {
                length = Length;
                height = Height;
            }
        }
        public class Customer
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public Address? CustomerAddress { get; set; }
            //Deconstruct for Customer  
            public void Deconstruct(out string? firstname, out string? lastname, out string? email, out Address? address)
            {
                firstname = FirstName;
                lastname = LastName;
                email = Email;
                address = CustomerAddress;
            }
        }
        public class Address
        {
            public int PostalCode { get; set; }
            public string? Street { get; set; }
            public string? Country { get; set; }
            // Deconstruct for Address  
            public void Deconstruct(out int postalCode, out string? street, out string? country)
            {
                postalCode = PostalCode;
                street = Street;
                country = Country;
            }
        }
    }
}