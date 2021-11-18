using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My programm");

            Console.WriteLine("User name-->");
            var name = Console.ReadLine();
           
            Console.WriteLine("Gender-->");
            var gender = Console.ReadLine();

            Console.WriteLine("Birthdate -->");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Weight-->");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Height-->");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();

        }
    }
}
