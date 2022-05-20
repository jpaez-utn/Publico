using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class Normal2Percentage : IPercentage
    {
        decimal IPercentage.BaseAmmount => 10;

        decimal? IPercentage.MaxAmmount => 100;

        UserType IPercentage.UserType => UserType.Normal;

        decimal IPercentage.GetPercentage()
        {
            return 80;
        }
    }
}
