﻿namespace AuthorizationMicroservice.Service
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPass)=>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPass);
    }
}
