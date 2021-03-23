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

        [HttpGet("getCarDetailsByBrand")]
        public IActionResult GetCarDetailsByBrand(int brandId)
        {
            var result = _carService.GetCarDetailsByBrand(brandId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet("getCarDetailsByColor")]
        public IActionResult GetCarDetailsByColor(int colorId)
        {
            var result = _carService.GetCarDetailsByColor(colorId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getCarDetailByCarId")]
        public IActionResult GetCarDetailByCarId(int carId)
        {
            var result = _carService.GetCarDetailByCarId(carId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getCarDetailsByColorAndBrand")]
        public IActionResult GetCarDetailsByColorAndBrand(int colorId,int brandId)
        {
            var result = _carService.GetCarDetailsByColorAndBrand(colorId, brandId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}