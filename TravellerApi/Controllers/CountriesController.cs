using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellerApi.Repository;

namespace TravellerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public CountriesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var countries = _repository.Country.GetAll();

                return Ok(countries);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error happened");
            }

        }

    }
}
