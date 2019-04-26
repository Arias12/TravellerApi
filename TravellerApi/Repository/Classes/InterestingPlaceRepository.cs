using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class InterestingPlaceRepository : Repository<InterestingPlace>, IInterestingPlaceRepository
    {
        public InterestingPlaceRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }

        public InterestingPlace GetInterestingPlace(Guid interestingPlaceId)
        {
            return Find(interestingPlace => interestingPlace.InterestingPlaceId.Equals(interestingPlaceId)).FirstOrDefault();
        }

        public InterestingPlace GetInterestingPlace(string interestingPlaceName)
        {
            return Find(interestingPlace => interestingPlace.Name.Equals(interestingPlaceName)).FirstOrDefault();
        }

        public IEnumerable<InterestingPlace> GetPlacesForCity(string cityName)
        {
            return _travellerDbContext.InterestingPlace.Where(i => i.City.Name == cityName).AsEnumerable();
        }

        public void DeleteInterestingPlace(InterestingPlace interestingPlace)
        {
            Delete(interestingPlace);
            Save();
        }

        public void CreateInterestingPlace(InterestingPlace interestingPlace)
        {
            interestingPlace.InterestingPlaceId= Guid.NewGuid();
            Create(interestingPlace);
            Save();
        }

        public void UpdateInterestingPlace(Guid id, InterestingPlace interestingPlace)
        {
            interestingPlace.InterestingPlaceId = id;
            Update(interestingPlace);
        }
    }
}
