using System;

namespace App.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string email) : base($"User with {email} not found"){}
    }
}