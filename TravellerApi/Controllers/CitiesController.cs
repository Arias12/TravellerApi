﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using TravellerApi.Model;
using TravellerApi.ModelDTO;
using TravellerApi.Repository;

namespace TravellerApi.Controllers
{
    [Route("api/countries/{countryName}")]
    public class CitiesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CitiesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<City> cityItems = _repository.City.GetAll().ToList();

                if (cityItems.Count() == 0)
                {
                    return NotFound("Cities not found");
                }

                var model = Mapper.Map<List<CityDTO>>(cityItems);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpGet("{id:Guid}", Name="CityById")]
        public IActionResult GetCity(Guid id)
        {
            try
            {
                var city = _repository.City.GetCity(id);

                if (city == null)
                {
                    return NotFound("Cannot find current City");
                }

                var model = Mapper.Map<CityDTO>(city);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpGet("{name}", Name = "CityByName")]
        public IActionResult GetCity(string name)
        {
            try
            {
                var city = _repository.City.GetCity(name);
                if (city == null)
                {
                    return NotFound("Cannot find current City");
                }

                var model = Mapper.Map<CityDTO>(city);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }

        }


    }
}
