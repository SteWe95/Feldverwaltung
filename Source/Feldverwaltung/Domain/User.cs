using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Position Position { get; set; }

        public User(string username, string password, Position position)
        {
            Username = username;
            Password = password;
            Position = position;
        }
    }
}
