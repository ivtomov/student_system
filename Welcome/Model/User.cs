using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using System;

namespace Welcome.Model
{
    public class User
    {

        private int id;
        private DateTime expires;

        public virtual int Id { get; set; }
        public DateTime Expires { get; set; }

        private string _password;

        public string Name { get; set; }
        // Modify the Password property to encrypt on set
        public string Password
        {
            get => DecryptPassword(_password); 
            set => _password = EncryptPassword(value); 
        }
        public UserRolesEnum Role { get; set; }
        public string FacultyNumber { get; set; }
        public string Email { get; set; }

        private string EncryptPassword(string input)
        {
            // Basic Caesar cipher for illustration
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + 3); // Shift character by 3
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        private string DecryptPassword(string input)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter - 3); // Shift character back by 3
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
