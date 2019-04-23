using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public interface ICityRepository : IRepository<City>
    {
        City GetCity(Guid cityId);
        City GetCity(string name);
        void  DeleteCity(City city);
        void  CreateCity(City city);
        IEnumerable<City> GetCitiesForCountry(string countryName);
    }
}
