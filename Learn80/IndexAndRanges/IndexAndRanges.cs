using System;
using System.Linq;

namespace Learn80.IndicesAndRanges
{
    public static class IndexAndRanges
    {
        public static void Test()
        {
            SystemIndex();
            SystemRange();
        }

        private static void SystemRange()
        {
            //Create an Array of Countries
            var countries = new string[]
            {
                //Index From Start      
                "INDIA",                //0                                  
                "USA",                  //1                     
                "UK",                   //2                     
                "NZ",                   //3                     
                "CANADA",               //4                   
                "CHINA",                //5                    
                "NEPAL",                //6                    
                "RUSIA",                //7                    
                "SRILANKA",             //8                  
                "INDONESIA"             //9                     
            };
            //Fetching the First Four Countries 
            //It will fetch elements from Index Position 0 to Index Position 4-1
            var subCountries = countries[0..4]; //INDIA USA UK NZ
            //old: var subCountries = countries.ToList().GetRange(0,4).ToArray(); //INDIA USA UK NZ
            
            //Printing Sub Country Names
            foreach (var country in subCountries)
            {
                Console.WriteLine(country);
            }
            
            Range phrase = 1..5;
            var subCountriesNext = countries[phrase]; 
            foreach (var country in subCountriesNext)
            {
                Console.WriteLine(country);
            }
            
            var helloWorldStr = "Hello, World!";
            var hello = helloWorldStr[..5]; // Take 5 from the begin
            Console.WriteLine(hello); // Output: Hello
            var world = helloWorldStr[^6..]; // Take the last 6 characters from behind
            Console.WriteLine(world); // Output: World!
        }

        public static void SystemIndex()
        {
            var countries = new string[]
            {
                "INDIA",
                "USA",
                "UK",
                "NZ",
                "CANADA",
                "CHINA",
                "NEPAL",
                "RUSIA",
                "SRILANKA",
                "INDONESIA"
            };
            Index i1 = 4;
            Console.WriteLine($"{countries[i1]}"); // Output: "CANADA"
            // Index 4 from end of the collection
            //Old Method: var LastValue = myArray[myArray.Length-4]
            //New Method: var LastValue = myArray[^4]
            Index i2 = ^4;
            Console.WriteLine($"{countries[i2]}"); // Output: "NEPAL"

            //Create an Array of Countries
            var countries2 = new string[]
            {
                //Index From Start      //Index From End
                "INDIA", //0                     //^10               
                "USA", //1                     //^9
                "UK", //2                     //^8
                "NZ", //3                     //^7
                "CANADA", //4                     //^6
                "CHINA", //5                     //^5
                "NEPAL", //6                     //^4
                "RUSIA", //7                     //^3
                "SRILANKA", //8                     //^2
                "INDONESIA" //9                     //^1
            };
            // Index 0 from end of the collection
            // Index i22 = ^0;
            //Console.WriteLine($"{countries2[i22]}"); // Output: "Exception"
            Index i22 = ^1;
            Console.WriteLine($"{countries2[i22]}"); // INDONESIA
        }
    }
}