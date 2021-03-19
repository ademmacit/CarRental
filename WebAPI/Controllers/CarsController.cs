using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerCrudBase<Car, ICarService>
    {
        ICarService _carService;

        public CarsController(ICarService service) : base(service)
        {
            _carService = service;
        }

        [HttpGet("getCarDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}