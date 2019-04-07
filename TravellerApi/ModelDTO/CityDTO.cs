using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.ModelDTO
{
    public class CityDTO
    {
        public string Name { get; set; }
        public CountryDTO Country { get; set; }

    }
}
