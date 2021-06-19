using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            String arg = args?.Length > 0 ? args?[0] : "Abner";  
            Console.WriteLine($"Hello, {arg}! Nice to meet you");
        }
    }
}
