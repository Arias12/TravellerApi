using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }
        

        public void CreateCountry(Country country)
        {
            country.CountryId = Guid.NewGuid();
            Create(country);
            Save();
        }

        public void DeleteCountry(Country country)
        {
            Delete(country);
            Save();
        }

        public Country GetCountry(Guid countryID)
        {
            return Find(country => country.CountryId.Equals(countryID)).FirstOrDefault();
        }

        public void UpdateCountry(Guid id, Country country)
        {
            country.CountryId = id;
            Update(country);
        }
    }
}
