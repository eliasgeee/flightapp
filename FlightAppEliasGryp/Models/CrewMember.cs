using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class CrewMember : ApplicationUser
    {
        public const int MIN_LENGTH_PASSWORD = 6;
        public const int MIN_LENGTH_USERNAME = 2;

        private string _password = "";
        public string Password { get { return _password; } set {
                if (!IsValidPassword(value))
                    throw new ArgumentException($"Password must be min {MIN_LENGTH_PASSWORD} characters");
                Set(ref _password, value); }
        }

        private string _userName = "";
        public string UserName {
            get { return _userName; }
            set
            {
                if (!IsValidUserName(value))
                    throw new ArgumentException($"Username must be min {MIN_LENGTH_USERNAME} characters");
                Set(ref _userName, value);
            }
        }

        public bool IsValidPassword(string password) {  return password.Length >= MIN_LENGTH_PASSWORD; }
        public bool IsValidUserName(string username) { return username.Length >= MIN_LENGTH_USERNAME; }
    }
}
