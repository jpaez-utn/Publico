using Sat.Recruitment.Api.Model;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Business.Percentage
{
    public class PercentageResolver
    {
        private readonly List<IPercentage> _strategies = new List<IPercentage>();

        public PercentageResolver()
        {
            _strategies.Add(new PremiumPercentage());
            _strategies.Add(new Normal1Percentage());
            _strategies.Add(new Normal2Percentage());
            _strategies.Add(new SuperUserPercentage());
        }
        public IPercentage Resolve(UserType userType, decimal money)
        {
            return _strategies.Find((x) => x.UserType == userType
                                            && money > x.BaseAmmount
                                            && (!x.MaxAmmount.HasValue || money <= x.MaxAmmount.Value));

        }
    }
}
