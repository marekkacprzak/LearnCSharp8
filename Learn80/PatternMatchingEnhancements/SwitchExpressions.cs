using System;

namespace Learn80.PatternMatchingEnhancements
{
    public static class SwitchExpressions
    {
        public static void Test()
        {
            Console.WriteLine("Enter Day");
            var day = Console.ReadLine();
            string message;
            switch (day?.ToUpper())
            {
                case "SUNDAY":
                    message = "Weekend";
                    break;
                case "MONDAY":
                    message = "start of the weekday";
                    break;
                case "FRIDAY":
                    message = "end of the weekday";
                    break;
                default:
                    message = "Invalid day";
                    break;
            }
            Console.WriteLine($"{day} is {message}");
            message = day?.ToUpper() switch
            {
                "SUNDAY" => "Weekend",
                "MONDAY" => "start of the weekday",
                "FRIDAY" => "end of the weekday",
                _ => "Invalid day"
            };
            Console.WriteLine($"{day} is {message}");
            
            var direction = Direction.Left;
            Console.WriteLine($"Map view direction is {direction}");
            Orientation? orientation = direction switch
            {
                Direction.Up => Orientation.North,
                Direction.Down => Orientation.South,
                Direction.Left => Orientation.West,
                Direction.Right => Orientation.East,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
            };
            Console.WriteLine($"Cardinal Orientation is {orientation}");
        }
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public enum Orientation
        {
            North,
            South,
            East,
            West
        }
    }
}