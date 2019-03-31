using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TravellerDbContext _travellerContext;
        private ICityRepository _city;
        private ICountryRepository _country;
        private ICommentRepository _comment;
        private IInterestingPlaceRepository _interestingPlace;


        public RepositoryWrapper(TravellerDbContext travellerContext)
        {
            _travellerContext = travellerContext;
        }

        public ICityRepository City
        {
            get
            {
                if (_city == null)
                {
                    _city = new CityRepository(_travellerContext);
                }

                return _city;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_travellerContext);
                }

                return _country;
            }
        }

        public IInterestingPlaceRepository InterestingPlace
        {
            get
            {
                if (_interestingPlace == null)
                {
                    _interestingPlace = new InterestingPlaceRepository(_travellerContext);
                }

                return _interestingPlace;
            }
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                {
                    _comment = new CommentRepository(_travellerContext);
                }

                return _comment;
            }
        }
    }
}
