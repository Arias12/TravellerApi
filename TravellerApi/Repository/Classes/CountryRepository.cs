﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravellerApi.Model;

namespace TravellerApi.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(TravellerDbContext travellerContext) : base(travellerContext)
        {
        }


        public void CreateCountry(Country country)
        {
            country.CountryId = Guid.NewGuid();
            Create(country);
            Save();
        }

        public void DeleteCountry(Country country)
        {
            Delete(country);
            Save();
        }

        public Country GetCountry(Guid countryId)
        {
            return Find(country => country.CountryId.Equals(countryId)).FirstOrDefault();
        }

        public void UpdateCountry(Guid id, Country country)
        {
            country.CountryId = id;
            Update(country);
        }

        public bool CountryExist(Guid countryId)
        {
            var foundCountry = Find(country => country.CountryId.Equals(countryId)).FirstOrDefault();
            if (foundCountry == null)
                return false;
            return true;
        }

        public IEnumerable<Country> GetAll()
        {
            var countryItems = _travellerDbContext.Country.ToList();
            return countryItems;
        }

        public Country GetCountry(string name)
        {
            var foundCountry = Find(country => country.Name.Equals(name)).FirstOrDefault();
            return foundCountry;
        }
    }
}