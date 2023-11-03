using System;

namespace Learn80.NullableReferenceTypes
{
    public static class NullableReferenceTypes
    {
        //<Nullable>enable</Nullable>
        /// <summary>
        /// &lt;Nullable&gt;enable&lt;/Nullable&gt; in csproj
        /// </summary>
        public static void Test()
        {
            string message = null;
            // warning: dereference null.
            try
            {
                Console.WriteLine($"The length of the message is {message.Length}");
            }
            catch{}
            var originalMessage = message;
            message = "Hello, World!";
            // No warning. Analysis determined "message" is not null.
            Console.WriteLine($"The length of the message is {message.Length}");
            // warning!
            try
            {
                Console.WriteLine(originalMessage.Length);
            }
            catch{}
            
            // Is Ok, nullableString it can be null and it is null.
            string? nullableString = null;
            // WARNING: nullableString is null! Take care!
            try
            {
                Console.WriteLine(nullableString.Length);   
            }
            catch{}
        }
    }
}