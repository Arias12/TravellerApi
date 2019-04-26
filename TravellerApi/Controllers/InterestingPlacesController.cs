using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravellerApi.Repository;

namespace TravellerApi.Controllers
{
    [Route("api/countries/{countryName}/cities/{cityName}/places")]
    public class InterestingPlacesController
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public InterestingPlacesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        

    }
}
