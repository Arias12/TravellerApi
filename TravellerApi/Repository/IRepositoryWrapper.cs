using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerApi.Repository
{
    public interface IRepositoryWrapper
    {
        ICityRepository City { get;  }
        ICountryRepository Country { get;  }
        IInterestingPlaceRepository InterestingPlace { get;  }
        ICommentRepository Comment { get;  }
    }
}
