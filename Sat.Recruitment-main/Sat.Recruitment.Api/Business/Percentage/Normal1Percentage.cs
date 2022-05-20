using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class Normal1Percentage : IPercentage
    {
        public decimal BaseAmmount => 100;

        public decimal? MaxAmmount => null;

        public UserType UserType => UserType.Normal;

        public decimal GetPercentage()
        {
            return 12;
        }
    }
}
