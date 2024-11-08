using System.ComponentModel;
using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;


namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                /*var user = new User
                {
                    Name = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.Display();


                view.DisplayError();*/

                UserData userData = new UserData();
                User studentUser = new User()
                {
                    Name = "student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(studentUser);

               
                User student2 = new User()
                {
                    Name = "student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                userData.AddUser(student2);


                User professor = new User()
                {
                    Name = "Professor",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                userData.AddUser(professor);

                User admin = new User()
                {
                    Name = "Admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN
                };
                userData.AddUser(admin);

                Console.WriteLine("Welcome! Enter username & password:");
                string username = Console.ReadLine();
                string password = Console.ReadLine(); 

                
                if (userData.ValidateCredentials(username, password))
                {
                    User user = userData.GetUser(username, password);
                    Console.WriteLine(user.ToString());
                }
                else
                {                    
                    throw new Exception("User not found");
                }
            }                                   
            catch (Exception e) {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally { Console.WriteLine("Execute in any case"); }
        }
    }
}
