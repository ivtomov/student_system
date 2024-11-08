using System;
using System.Linq;
using DataLayer.Database;
using DataLayer.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DAtabase creation problem: {ex.Message}");
                    return; 
                }

                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.STUDENT,
                    Email = "example@mail.com",
                    FacultyNumber = "123456789",
                }); ;
                context.SaveChanges();

                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (user != null)
                {
                    Console.WriteLine("Valid user");
                }
                else
                {
                    Console.WriteLine("Invalid data");
                }

                var users = context.Users.ToList();
                Console.ReadKey();
            }
        }
    }
}
