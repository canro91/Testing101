using Stringie;
using System;
using System.Diagnostics;

namespace TestProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var helloWorld = ", world!".Insert("Hello");
            if (helloWorld != "Hola, mundo!")
            {
                throw new Exception("Your mission, Jim, should you decide to accept it, is to delete this project and write real unit tests. This code will self-destruct in five seconds. Good luck, Jim. 5...4...3...2...1...smoke coming out of your computer");
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}