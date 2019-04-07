using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.ModelDTO
{
    public class InterestingPlaceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CityDTO City { get; set; }
    }
}
