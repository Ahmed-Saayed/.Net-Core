﻿namespace JWT2Learn.Entites
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
