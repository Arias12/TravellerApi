using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;
using TravellerApi.ModelDTO;

namespace TravellerApi.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountry(Guid id);
        void UpdateCountry(Guid id, Country country);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
        bool CountryExist(Guid id);
        IEnumerable<Country> GetAll();
    }
}
