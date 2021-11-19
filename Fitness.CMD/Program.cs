using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
// join entity
namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My programm");

            Console.WriteLine("User name-->");

            var name = Console.ReadLine();
           
            var userService = new UserService(name);

            if(userService.IsNewUser)
            {
                Console.Write("Gender-->");
                var gender = Console.ReadLine();
                var birthdate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userService.SetNewUserData(gender, birthdate, weight, height);
            }

            Console.WriteLine(userService.CurrentUser);
            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("BirthDate (dd.mm.yyy)-->");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect birthDate formate");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Input-->{name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect {name} formate");
                }
            }

        }
    }
}
