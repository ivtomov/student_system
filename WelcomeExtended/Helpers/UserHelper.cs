using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static string ToString(this User user) {
            return user.ToString();
        }

        public static bool ValidateCredentials(this UserData data, string name, string password)
        {
            if (name == null || password == null)
            {
                throw new ArgumentNullException("The name and password cannot be empty!");
            }

            return data.ValidateUser(name, password);
        }



    }
}
