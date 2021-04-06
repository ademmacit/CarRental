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
    public class CustomerFindeksController : ControllerBase
    {

        ICustomerFindeksService _CustomerFindeksService;

        public CustomerFindeksController(ICustomerFindeksService service)
        {
            _CustomerFindeksService = service;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _CustomerFindeksService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _CustomerFindeksService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getByCustomerId")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _CustomerFindeksService.GetByCustomerId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerFindeks item)
        {
            var result = _CustomerFindeksService.Add(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CustomerFindeks item)
        {
            var result = _CustomerFindeksService.Delete(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(CustomerFindeks item)
        {
            var result = _CustomerFindeksService.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}