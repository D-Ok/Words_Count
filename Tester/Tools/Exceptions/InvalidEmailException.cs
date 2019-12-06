using System;

namespace Tester.Tools.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email {email}")
        {

        }
    }
}
