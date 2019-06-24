using System;

namespace App.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email):base($"Invalid email format in {email}"){}
    }
}