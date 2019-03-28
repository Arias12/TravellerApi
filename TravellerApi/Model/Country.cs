using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TravellerApi.Model
{
    public class Country
    {
        #region Country
        [Key] 
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        #endregion

        public ICollection<City> Cities { get; set; }
    }
}
