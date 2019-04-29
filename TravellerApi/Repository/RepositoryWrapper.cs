using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICityRepository _city;
        private ICommentRepository _comment;
        private ICountryRepository _country;
        private IInterestingPlaceRepository _interestingPlace;
        private readonly TravellerDbContext _travellerContext;


        public RepositoryWrapper(TravellerDbContext travellerContext)
        {
            _travellerContext = travellerContext;
        }

        public ICityRepository City
        {
            get
            {
                if (_city == null) _city = new CityRepository(_travellerContext);

                return _city;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null) _country = new CountryRepository(_travellerContext);

                return _country;
            }
        }

        public IInterestingPlaceRepository InterestingPlace
        {
            get
            {
                if (_interestingPlace == null) _interestingPlace = new InterestingPlaceRepository(_travellerContext);

                return _interestingPlace;
            }
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null) _comment = new CommentRepository(_travellerContext);

                return _comment;
            }
        }
    }
}