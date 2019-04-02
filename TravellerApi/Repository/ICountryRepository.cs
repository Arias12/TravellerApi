using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountry(Guid id);
        void UpdateCountry(Country foundCountry, Country country);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
