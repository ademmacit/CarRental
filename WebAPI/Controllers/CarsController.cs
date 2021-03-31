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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService service)
        {
            _carService = service;
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car item)
        {
            var result = _carService.Add(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car item)
        {
            var result = _carService.Delete(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car item)
        {
            var result = _carService.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
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