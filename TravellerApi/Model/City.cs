using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerApi.Model
{
    public class City
    {
        #region City
        [Key]
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        #endregion

        public ICollection<InterestingPlace> InterestingPlaces { get; set; }

    }
}
