using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                Name = "Ivan",
                Password = "password123",
                Role = UserRolesEnum.STUDENT,
                FacultyNumber = "121221090",
                Email = "itomov@tu-sofia.bg"
            };

            UserViewModel userViewModel = new(user);

            UserView userView = new(userViewModel);

            userView.Display();

        
        }
    }
}
