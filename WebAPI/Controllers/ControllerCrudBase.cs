using Core.Business;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ControllerCrudBase<TEntity,TService> : ControllerBase
        where TService :class ,ICrudService<TEntity>
        where TEntity : class,IEntity
    {
        TService _Service;

        public ControllerCrudBase(TService service)
        {
            _Service = service;
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetAll()
        {
            var result = _Service.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromBody] int id)
        {
            var result = _Service.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TEntity item)
        {
            var result = _Service.Add(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TEntity item)
        {
            var result = _Service.Delete(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(TEntity item)
        {
            var result = _Service.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
