using System.Text.RegularExpressions;
using Tester.Tools.Exceptions;

/// <summary>
/// Validates user input fields name, email and login
/// </summary>

namespace Tester.Tools
{
    internal static class Validator
    {
        private static readonly string EmailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"+ @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private static readonly string NamePattern = @"^[a-zA-Z]+$";
        private static readonly string LoginPattern = @"^(\w)+$";

        internal static void ValidateNameAttribute(string name)
        {
            if (!Regex.IsMatch(name, NamePattern))
                throw new InvalidNameAttributeException(name);

        }

        internal static void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email,
                EmailPattern,
                RegexOptions.IgnoreCase))
                throw new InvalidEmailException(email);
        }

        internal static void ValidateLogin(string login)
        {
            if (!Regex.IsMatch(login, LoginPattern))
                throw new InvalidLoginException(login);
        }


        
    }
}
