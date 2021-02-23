﻿using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = new List<CityWithoutPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDto()
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name
                };
                
                foreach (var poi in city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(
                        new PointOfInterestDto()
                        {
                            Id = poi.Id,
                            Description = poi.Description,
                            Name = poi.Name
                        });
                }

                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterest = new CityWithoutPointsOfInterestDto()
            {
                Id = city.Id,
                Description = city.Description,
                Name = city.Name
            };

            return Ok(cityWithoutPointsOfInterest);
        }
    }
}
