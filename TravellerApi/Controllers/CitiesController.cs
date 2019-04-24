using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
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

        [HttpGet]
        public IActionResult GetCitiesForCountry(string name)
        {
            try
            {
                List<City> cityItems = _repository.City.GetCitiesForCountry(name).ToList();
                if (cityItems.Count() == 0)
                {
                    return NotFound("No cities found");
                }

                var model = Mapper.Map<List<CountryDTO>>(cityItems);
                return Ok(model);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody] City city)
        {
            try
            {
                if (city == null)
                {
                    return BadRequest("City object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (!_repository.City.Save())
                {
                    throw new Exception("Updating country failed on save");
                }

                var model = Mapper.Map<City>(city);
                _repository.City.CreateCity(model);

                return CreatedAtRoute("CityById", new {id = city.CityId}, city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }


        [HttpPut("{name}")]
        public IActionResult UpdateCity(string name, [FromBody] CityDTO city)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var foundCity = _repository.City.GetCity(name);

                if (foundCity == null)
                {
                    return NotFound();
                }

                var id = foundCity.CityId;
                Mapper.Map(city, foundCity);

                
                _repository.City.UpdateCity(id, foundCity);

                if (!_repository.City.Save())
                {
                    throw new Exception("Updating city failed on save");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error");
            }
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteCity(string name)
        {
            try
            {
                var city = _repository.City.GetCity(name);

                if (city == null)
                {
                    return NotFound();
                }

                _repository.City.DeleteCity(city);

                if (!_repository.City.Save())
                {
                    throw new Exception("Deleting city failed on save");
                }
                return NoContent();
            }

            catch
            {
                return StatusCode(500, "Server error");
            }
        }

    }
}

