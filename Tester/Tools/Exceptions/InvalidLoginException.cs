using System;

namespace Tester.Tools.Exceptions
{
    internal class InvalidLoginException: Exception
    {
        public InvalidLoginException(string login) : base($"Invalid login {login}")
        {

        }
    }
}
