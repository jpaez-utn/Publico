using Sat.Recruitment.Api.Model;
namespace Sat.Recruitment.Api.Business.Percentage
{
    public interface IPercentage
    {
        decimal BaseAmmount { get; }
        decimal? MaxAmmount { get; }
        UserType UserType { get; }

        decimal GetPercentage();

    }
}
