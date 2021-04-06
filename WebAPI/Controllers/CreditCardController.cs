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
    public class CreditCardController : ControllerBase
    {

        ICreditCardService _CreditCardService;

        public CreditCardController(ICreditCardService service)
        {
            _CreditCardService = service;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _CreditCardService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _CreditCardService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public IActionResult getByUserId(int userId)
        {
            var result = _CreditCardService.GetByUserId(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard item)
        {
            var result = _CreditCardService.Add(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard item)
        {
            var result = _CreditCardService.Delete(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard item)
        {
            var result = _CreditCardService.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}