using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class SuperUserPercentage : IPercentage
    {
        public decimal BaseAmmount => 100;

        public decimal? MaxAmmount => null;

        public UserType UserType => UserType.SuperUser;

        public decimal GetPercentage()
        {
            return 20;
        }
    }
}
