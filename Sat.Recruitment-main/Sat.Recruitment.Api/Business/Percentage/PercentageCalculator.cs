using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class PercentageCalculator
    {
        public decimal Calculate(UserType userType, decimal money)
        {
            PercentageResolver percentageResolver = new PercentageResolver();
            IPercentage percentage = percentageResolver.Resolve(userType, money);
            return percentage == null ? 0 : percentage.GetPercentage();
        }

    }
}
