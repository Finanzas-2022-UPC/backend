﻿namespace FinanzasGrupo2API.Users.Resources
{
    public class SaveUserResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string URLImage { get; set; }
    }
}
