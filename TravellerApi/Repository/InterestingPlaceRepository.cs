﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class InterestingPlaceRepository : Repository<InterestingPlace>, IInterestingPlaceRepository
    {
        public InterestingPlaceRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }
    }
}
