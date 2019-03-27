using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerApi.Model
{
    public class Comment
    {
        #region Comment
        [Key]
        public Guid CommentId { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        #endregion
        public InterestingPlace InterestingPlace { get; set; }
    }
}
