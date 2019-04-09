﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravellerApi.Model;
using TravellerApi.ModelDTO;
using TravellerApi.Repository;

namespace TravellerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CountriesController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 

            try
            {
                var countries = _repository.Country.GetAll();

                if (countries == null)
                {
                    return NotFound();
                }

                var model = Mapper.Map<CountryDTO>(countries);
                return Ok(model);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }

        }

        [HttpGet("{id}", Name = "CountryById")]
        public IActionResult GetCountry(Guid id)
        {
            try
            {
                
                var country = _repository.Country.GetCountry(id);
                if (country == null)
                {
                    return NotFound();
                }

                var model = Mapper.Map<CountryDTO>(country);
                return Ok(model);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest("Country object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var model = Mapper.Map<Country>(country);
                _repository.Country.CreateCountry(model);
                return CreatedAtRoute("CountryById", new {id = country.CountryId}, country);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCoubtry(Guid id, [FromBody] Country country)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var foundCountry =_repository.Country.GetCountry(id);

                if (foundCountry == null)
                {
                    return NotFound();
                }
                
                _repository.Country.UpdateCountry(id, country);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }

            [HttpDelete("{id}")]
            public IActionResult DeleteCountry(Guid id)
            {
                try
                {
                    var country = _repository.Country.GetCountry(id);
                    if (country == null)
                    {
                        return NotFound();
                    }

                    _repository.Country.Delete(country);

                    return NoContent();
                }

                catch
                {
                    return StatusCode(500, "Server error");
                }
            }
    }
}
