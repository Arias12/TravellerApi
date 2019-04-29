using System;
using System.Collections.Generic;
using System.Linq;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }

        public City GetCity(Guid cityId)
        {
            return Find(city => city.CityId.Equals(cityId)).FirstOrDefault();
        }

        public City GetCity(string name)
        {
            return Find(city => city.Name.Equals(name)).FirstOrDefault();
        }

        public void DeleteCity(City city)
        {
            Delete(city);
            Save();
        }

        public void CreateCity(City city)
        {
            city.CityId = Guid.NewGuid();
            Create(city);
            Save();
        }

        public IEnumerable<City> GetCitiesForCountry(string countryName)
        {
            return _travellerDbContext.City.Where(c => c.Country.Name == countryName).AsEnumerable();
        }

        public void UpdateCity(Guid id, City city)
        {
            city.CityId = id;
            Update(city);
        }
    }
}