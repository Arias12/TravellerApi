using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerApi.Model
{
    public class InterestingPlace
    {
        #region InterestingPlace
        [Key]
        public Guid InterestingPlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        #endregion
        public ICollection<Comment> Comments { get; set; }
    }
}
