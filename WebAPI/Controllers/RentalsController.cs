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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService service)
        {
            _rentalService = service;
        }



        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromBody] int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental item)
        {
            var result = _rentalService.Add(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental item)
        {
            var result = _rentalService.Delete(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(Rental item)
        {
            var result = _rentalService.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
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