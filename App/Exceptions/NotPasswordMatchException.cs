using System;

namespace App.Exceptions
{
    public class NotPasswordMatchException : Exception
    {
        public NotPasswordMatchException() : base("Password you entered did not match"){}
    }
}