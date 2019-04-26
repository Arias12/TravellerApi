using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public interface IInterestingPlaceRepository : IRepository<InterestingPlace>
    {
        void CreateInterestingPlace(InterestingPlace interestingPlace);
        void DeleteInterestingPlace(InterestingPlace interestingPlace);
        InterestingPlace GetInterestingPlace(Guid interestingPlaceId);
        InterestingPlace GetInterestingPlace(string interestingPlaceName);
        IEnumerable<InterestingPlace> GetPlacesForCity(string cityName);
        void UpdateInterestingPlace(Guid id, InterestingPlace interestingPlace);
    }
}
