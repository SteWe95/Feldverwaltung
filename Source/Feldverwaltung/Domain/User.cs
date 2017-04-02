using System;

namespace Feldverwaltung.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid PositionId { get; set; }
        public Position Position { get; set; }

        public User(string username, string password, Position position)
        {
            Username = username;
            Password = password;
            Position = position;
        }

        public User()
        {
        }
    }
}
