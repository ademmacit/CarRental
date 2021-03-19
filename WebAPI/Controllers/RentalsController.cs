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
    public class RentalsController : ControllerCrudBase<Rental, IRentalService>
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService service) : base(service)
        {
            _rentalService = service;
        }

        [HttpGet("getRentalDetails")]
        public IActionResult GetCarDetails()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}