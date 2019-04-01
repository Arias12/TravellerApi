﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public interface ICityRepository : IRepository<City>
    {
        City GetCity(Guid cityId);
    }
}
