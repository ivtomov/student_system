using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData() {
            this._nextId = 0;
            _users = new List<User>();    
        }

        public void AddUser(User user) {
            user.Id = this._nextId++;
            _users.Add(user);
        }

        public void RemoveUser(User user) { 
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password){
            foreach (var user in _users) {
                if (user.Name == name && user.Password == password) {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password) 
        {
            return _users.Where(x => x.Name == name && x.Password == password)
                         .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password) 
        {
            var ret = from user in _users
                      where user.Name == name && user.Password== password
                      select user.Id;
            return ret != null ? true : false;
        }

        public User GetUser(string name, string password) 
        {
            var ret = from user in _users
                      where user.Name == name && user.Password == password
                      select user;
            return ret.First();
        }

        public void SetActive(string name, DateTime expires) 
        {   
            var ret = from user in _users
                      where user.Name == name
                      select user;

            User selectedUser = ret.First();

            if (selectedUser != null) {
                selectedUser.Expires = expires;
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        { 
            var ret = from user in _users
                      where user.Name == name
                      select user;

            User selectedUser = ret.First();

            if (selectedUser != null) {
                selectedUser.Role = role; 
            }
            
        }
    }
}
