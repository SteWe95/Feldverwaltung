﻿using System;

namespace Feldverwaltung.Domain
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual Position Position { get; set; }

        public User()
        {
        }
    }
}
