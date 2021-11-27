using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Etherna.SSL.Helpers
{
    public static class EmailHelper
    {
        // Consts.
        public const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        // Static methods.
        public static bool IsValidEmail(string email) =>
            Regex.IsMatch(email, EmailRegex, RegexOptions.IgnoreCase);

        public static string NormalizeEmail(string email)
        {
            if (email is null)
                throw new ArgumentNullException(nameof(email));

            email = email.ToUpper(CultureInfo.InvariantCulture); //to upper case

            var components = email.Split('@');
            var username = components[0];
            var domain = components[1];

            var cleanedUsername = username.Split('+')[0]; //remove chars after '+' symbol, if present

            return $"{cleanedUsername}@{domain}";
        }
    }
}
