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
    [Route("api/countries/{countryName}/cities/{cityName}/places")]
    public class InterestingPlacesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public InterestingPlacesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<InterestingPlace> interestingPlaceItems = _repository.InterestingPlace.GetAll().ToList();

                if (interestingPlaceItems.Count() == 0)
                {
                    return NotFound("Interesting places not found");
                }

                var model = Mapper.Map<List<InterestingPlaceDTO>>(interestingPlaceItems);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpGet("{id:Guid}", Name = "InterestingPlaceById")]
        public IActionResult GetInterestingPlace(Guid id)
        {
            try
            {
                var interestingPlace = _repository.InterestingPlace.GetInterestingPlace(id);

                if (interestingPlace == null)
                {
                    return NotFound("Cannot found this place!");
                }

                var model = Mapper.Map<InterestingPlaceDTO>(interestingPlace);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpGet("{name}", Name = "InterestingPlaceByName")]
        public IActionResult GetInterestingPlace(string name)
        {
            try
            {
                var interestingPlace = _repository.InterestingPlace.GetInterestingPlace(name);

                if (interestingPlace == null)
                {
                    return NotFound("An error happened");
                }

                var model = Mapper.Map<InterestingPlaceDTO>(interestingPlace);
                return Ok(model);
            }
            catch (Exception ex1)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpGet]
        public IActionResult GetPlacesForCity(string cityName)
        {
            try
            {
                IEnumerable<InterestingPlace> placeItems = _repository.InterestingPlace.GetPlacesForCity(cityName);

                if (placeItems.Count() == 0)
                {
                    return NotFound();
                }

                var model = Mapper.Map<IEnumerable<InterestingPlaceDTO>>(placeItems);
                return Ok(model); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpPost]
        public IActionResult CreateInterestingPlace([FromBody] InterestingPlace interestingPlace)
        {
            try
            {
                if (interestingPlace == null)
                {
                    return BadRequest("InterestingPlace object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (!_repository.InterestingPlace.Save())
                {
                    throw new Exception("Creating interesting place failed on save");
                }

                var model = Mapper.Map<InterestingPlace>(interestingPlace);
                _repository.InterestingPlace.CreateInterestingPlace(model);

                return CreatedAtRoute("InterestingPlaceByID", new {id = interestingPlace.InterestingPlaceId},
                    interestingPlace);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }

        [HttpPut("{name}")]
        public IActionResult UpdateInterestingPlace(string name, [FromBody] InterestingPlaceDTO interestingPlace)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (interestingPlace == null)
                {
                    return BadRequest("InterestingPlace object is null");
                }

                var foundPlace = _repository.InterestingPlace.GetInterestingPlace(name);

                if (foundPlace == null)
                {
                    return NotFound("Interesting place does not exist");
                }

                var id = foundPlace.InterestingPlaceId;
                Mapper.Map(interestingPlace, foundPlace);

                _repository.InterestingPlace.UpdateInterestingPlace(id, foundPlace);

                if (!_repository.InterestingPlace.Save())
                {
                    throw new Exception("Updating interesting place failed on save");
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }
        }


        [HttpDelete("{name}")]
        public IActionResult DeleteInterestingPlace(string name)
        {
            try
            {
                var interestingPlace = _repository.InterestingPlace.GetInterestingPlace(name);

                if (interestingPlace == null)
                {
                    return BadRequest("Interesting place does not exist");
                }

                _repository.InterestingPlace.DeleteInterestingPlace(interestingPlace);

                if (!_repository.InterestingPlace.Save())
                {
                    throw new Exception("Deleting interesting place failed on save");
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
