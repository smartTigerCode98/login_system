using System;

namespace App.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException():
            base("Your password must be between 6 characters and 15, have chars in upper and lower cases and also have numbers"){}
    }
}