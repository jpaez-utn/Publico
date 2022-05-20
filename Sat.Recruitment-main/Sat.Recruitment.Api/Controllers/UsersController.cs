using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.DAO;
using Sat.Recruitment.Api.Model;
using System.Diagnostics;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
        }


        [HttpPost]
        [Route("/create-user")]
        public Result CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            Result result = new Result();

            User newUser = Model.User.GetUserBasedOnInput(name, email, address, phone, userType, money);

            Validators.UserValidator validationRules = new Validators.UserValidator();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(newUser);

            if (validationResult.IsValid)
            {                
                if (!UserAlreadyExists(newUser))
                {
                    newUser.Money = GrantGift(newUser.Money, new Business.Percentage.PercentageCalculator().Calculate(newUser.UserType, newUser.Money));

                    Debug.WriteLine("User Created");

                    result.IsSuccess = true;
                    result.Errors = "User Created";

                }
                else
                {
                    Debug.WriteLine("The user is duplicated");
                    result.IsSuccess = false;
                    result.Errors = "The user is duplicated";
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Errors = validationResult.ToString("|");
            }

            return result;

        }

        private bool UserAlreadyExists(User user)
        {
            return new UserDAO().UserAlreadyExists(user);
        }

        private decimal GrantGift(decimal money, decimal percentage)
        {
            return money + money * percentage / 100;
        }
    }
}
