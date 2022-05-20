using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class PremiumPercentage : IPercentage
    {
        public decimal BaseAmmount => 100;

        public decimal? MaxAmmount => null;

        public UserType UserType => UserType.Premium;

        public decimal GetPercentage()
        {
            return 200;
        }
    }
}
