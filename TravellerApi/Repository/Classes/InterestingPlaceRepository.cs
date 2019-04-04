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
    }
}
