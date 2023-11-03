using System;

namespace Learn80.PatternMatchingEnhancements
{
    public static class TuplePatterns
    {
        static string SportsLike(string sport1, string sport2, string sport3)
        {
            var result = (sport1, sport2, sport3) switch
            {
                //matches if Cricket, Football, and Swimming given as input
                ("Cricket", "Football", "Swimming") => "I like Cricket, Football, and Swimming.",
                //matches if Cricket, Football, and Baseball given as input
                ("Cricket", "Football", "Baseball") => "I like Cricket, Football, and Baseball.",
                //matches if Hockey, Football, and Swimming given as input
                ("Hockey", "Football", "Swimming") => "I like Hockey, Football, and Swimming.",
                //matches if Table Tennis, Football, and Swimming given as input
                ("Table Tennis", "Football", "Swimming") => "I like Table Tennis, Football and Swimming.",
                //Default case
                (_, _, _) => "Invalid input!"
            };
            return result;
        }
        public static int GetOrderDiscount(CustomerOrder order)
        {
            return (order.PaymentMethod, order.Country) switch
            {
                (PaymentMethods.CreditCard, "India") => 20,
                (PaymentMethods.WireTransfer, "USA") => 15,
                (_, _) when order.Amount > 5000 => 10,
                _ => 0 // unknown or Default  
            };
        }
        public static void Test()
        {
            Console.WriteLine(SportsLike("Cricket", "Football", "Swimming"));
            Console.WriteLine(SportsLike("Cricket", "Football", "Racing"));
            
            CustomerOrder customerOrder1 = new CustomerOrder()
            {
                PaymentMethod = PaymentMethods.CreditCard,
                Country = "India",
                Amount = 2000
            };
            CustomerOrder customerOrder2 = new CustomerOrder()
            {
                PaymentMethod = PaymentMethods.WireTransfer,
                Country = "USA",
                Amount = 3000
            };
            Console.WriteLine($"Country: {customerOrder2.Country}, Payment Method : {customerOrder1.PaymentMethod}, Order Discount : {GetOrderDiscount(customerOrder1)}");
            Console.WriteLine($"Country: {customerOrder2.Country}, Payment Method : {customerOrder2.PaymentMethod}, Order Discount : {GetOrderDiscount(customerOrder2)}");
        }
        public class CustomerOrder
        {
            public PaymentMethods PaymentMethod { get; set; }
            public string? Country { get; set; }
            public double Amount { get; set; }
        }
        public enum PaymentMethods
        {
            CreditCard,
            WireTransfer
        }
    }
}