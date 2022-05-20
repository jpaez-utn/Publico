using System;
namespace Sat.Recruitment.Api.Formatter
{
    public class EmailFormatter
    {
        public static string Format(string email)
        {
            //Normalize email
            string[] splittedEmail = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            int atIndex = splittedEmail[0].IndexOf("+", StringComparison.Ordinal);

            splittedEmail[0] = atIndex < 0 ? splittedEmail[0].Replace(".", "") : splittedEmail[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { splittedEmail[0], splittedEmail[1] });
        }
    }
}
