using System;
using Sat.Recruitment.Api.Formatter;

namespace Sat.Recruitment.Api.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }

        public static User GetUserBasedOnInput(string name, string email, string address, string phone, string userType, string money)
        {
            return new User
            {
                Name = name,
                Email = EmailFormatter.Format(email),
                Address = address,
                Phone = phone,
                UserType = (UserType) Enum.Parse(typeof(UserType), userType),
                Money = decimal.Parse(money)
            };
        }
    }
}
