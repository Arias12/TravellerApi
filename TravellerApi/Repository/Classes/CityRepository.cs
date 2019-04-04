using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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





    }
}
